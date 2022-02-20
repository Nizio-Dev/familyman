using FamilyMan.Domain.Models;

namespace FamilyMan.Application.Dto.Responses;

public class MemberDto
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public Member HeadOfFamily { get; set; }
    public List<Member> Families { get; set; }
}