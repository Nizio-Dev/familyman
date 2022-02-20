using AutoMapper;
using FamilyMan.Application.Dto.Requests;
using FamilyMan.Application.Dto.Responses;
using FamilyMan.Application.Interfaces;
using FamilyMan.Application.Exceptions;
using FamilyMan.Domain.Models;

namespace FamilyMan.Application.Services;

public class MemberService : IMemberService
{

    private readonly IMapper _mapper;
    private readonly IIdentityService _identityService;
    private readonly IFamilyManDbContext _dbContext;

    public MemberService(IMapper mapper, IIdentityService identityService, IFamilyManDbContext dbContext)
    {
        _mapper = mapper;
        _identityService = identityService;
        _dbContext = dbContext;
    }


    public async Task<MemberDto> CreateMemberAsync(CreateMemberDto member)
    {

        var newMember = new Member()
        {
            Id = Guid.NewGuid(),
            Email = member.Email,
            Families = null,
            HeadOFamilies = null
        };

        await _identityService.AddUserAsync(newMember.Id, member.Email, member.Password);            
        _dbContext.Members.Add(newMember);
        await _dbContext.SaveChangesAsync();
   
        return _mapper.Map<MemberDto>(newMember);
    }

    public async Task<MemberDto> GetMemberByIdAsync(string id)
    {
        var member = await _dbContext.Members.FindAsync(id);

        if(member == null)
        {
            throw new ResourceNotFoundException("User not found.");
        }

        return _mapper.Map<MemberDto>(member);
    }

    public async Task<MemberDto> GetMemberByEmailAsync(string email)
    {
        var member = await _dbContext.Members.FindAsync(email);

        if(member == null)
        {
            throw new ResourceNotFoundException("User not found.");
        }

        return _mapper.Map<MemberDto>(member);
    }


    public async Task DeleteMemberByIdAsync(string id)
    {
        var member = await _dbContext.Members.FindAsync(id);

        if(member == null)
        {
            throw new ResourceNotFoundException("User not found.");
        }

        _dbContext.Members.Remove(member);
        await _dbContext.SaveChangesAsync();
    }


}