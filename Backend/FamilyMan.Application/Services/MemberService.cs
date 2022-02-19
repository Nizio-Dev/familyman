using AutoMapper;
using FamilyMan.Application.Dto.Requests;
using FamilyMan.Application.Dto.Responses;
using FamilyMan.Application.Interfaces;
using FamilyMan.Core.Models;
using Microsoft.EntityFrameworkCore;
using FamilyMan.Application.Exceptions;
using Microsoft.AspNetCore.Authorization;

namespace FamilyMan.Application.Services;

public class MemberService : IMemberService
{

    private readonly IFamilyManDbContext _context;
    private readonly IMapper _mapper;
    private readonly IIdentityService _identityService;
    private readonly IAuthorizationService _authorizationService;
    private readonly ICurrentUserService _currentUserService;
    private readonly IMemberOwnerOnlyRequirementFactory _memberOwnerOnlyRequirementFactory;

    public MemberService(IFamilyManDbContext context, IMapper mapper,
        IIdentityService identityService, IAuthorizationService authorizationService,
        ICurrentUserService currentUserService, IMemberOwnerOnlyRequirementFactory memberOwnerOnlyRequirementFactory)
    {
        _context = context;
        _mapper = mapper;
        _identityService = identityService;
        _authorizationService = authorizationService;
        _currentUserService = currentUserService;
        _memberOwnerOnlyRequirementFactory = memberOwnerOnlyRequirementFactory;
    }


    public async Task<MemberDto> CreateMemberAsync(CreateMemberDto member)
    {
        var memberExists = await _context.Members.FirstOrDefaultAsync(m =>m.Email == member.Email);

        var newMember = new Member()
        {
            Email = member.Email
        };
            
        var addMember = await _context.Members.AddAsync(newMember);
        var addIdentity = await _identityService.AddUserAsync(newMember.Id, member.Email, member.Password);
        
        await _context.SaveChangesAsync();
        
        return _mapper.Map<MemberDto>(newMember);
    }

    public async Task<MemberDto> GetMemberByIdAsync(string id)
    {
        var member = await _context.Members.FirstOrDefaultAsync(m => m.Id.ToString() == id);

        if(member == null)
        {
            throw new ResourceNotFoundException("User not found.");
        }

        var testFactory = _memberOwnerOnlyRequirementFactory.Create() as IAuthorizationRequirement; // Testing
        var testListReq = new List<IAuthorizationRequirement>(){testFactory}; // Testing

        var authorization = await _authorizationService.AuthorizeAsync(_currentUserService.MemberIdentity, member,  //Testing
            testListReq);

        if (!authorization.Succeeded)
        {
            throw new ForbiddenException("Access forbidden.");
        }

        return _mapper.Map<MemberDto>(member);
    }

    public async Task<MemberDto> GetMemberByEmailAsync(string email)
    {
        var member = await _context.Members.FirstOrDefaultAsync(m => m.Email == email);

        if(member == null)
        {
            throw new ResourceNotFoundException("User not found.");
        }

        return _mapper.Map<MemberDto>(member);
    }


    public async Task DeleteMemberByIdAsync(string id)
    {
        var member = _context.Members.FirstOrDefault(m => m.Id.ToString() == id);

        if(member == null)
        {
            throw new ResourceNotFoundException("User not found.");
        }

        _context.Members.Remove(member);

        await _context.SaveChangesAsync();

    }


}