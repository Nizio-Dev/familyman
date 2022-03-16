using FamilyMan.Application.Dto.Requests;
using FamilyMan.Application.Dto.Responses;

namespace FamilyMan.Application.Interfaces;

public interface IMemberService
{
    Task<MemberDto> CreateMemberAsync(CreateMemberDto member);

    Task<MemberDto> GetMemberByIdAsync(string id);

    Task<MemberDto> GetMemberByEmailAsync(string email);

    Task DeleteMemberByIdAsync(string id);
}