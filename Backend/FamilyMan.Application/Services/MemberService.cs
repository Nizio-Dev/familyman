using AutoMapper;
using FamilyMan.Application.Dto.Requests;
using FamilyMan.Application.Dto.Responses;
using FamilyMan.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using FamilyMan.Application.Exceptions;
using Microsoft.AspNetCore.Authorization;
using FamilyMan.Domain.Models;

namespace FamilyMan.Application.Services;

public class MemberService : IMemberService
{

    private readonly IMapper _mapper;
    private readonly IIdentityService _identityService;
    private readonly IUnitOfWork _unitOfWork;

    public MemberService(IMapper mapper,
        IIdentityService identityService, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _identityService = identityService;
        _unitOfWork = unitOfWork;
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
        _unitOfWork.Members.Add(newMember);
        await _unitOfWork.CompleteAsync();
   
        return _mapper.Map<MemberDto>(newMember);
    }

    public async Task<MemberDto> GetMemberByIdAsync(string id)
    {
        var member = await _unitOfWork.Members.GetByIdAsync(id);

        if(member == null)
        {
            throw new ResourceNotFoundException("User not found.");
        }

        return _mapper.Map<MemberDto>(member);
    }

    public async Task<MemberDto> GetMemberByEmailAsync(string email)
    {
        var member = await _unitOfWork.Members.GetByEmailAsync(email);

        if(member == null)
        {
            throw new ResourceNotFoundException("User not found.");
        }

        return _mapper.Map<MemberDto>(member);
    }


    public async Task DeleteMemberByIdAsync(string id)
    {
        var member = await _unitOfWork.Members.GetByIdAsync(id);

        if(member == null)
        {
            throw new ResourceNotFoundException("User not found.");
        }

        _unitOfWork.Members.Delete(member);
        await _unitOfWork.CompleteAsync();
    }


}