namespace FamilyMan.Application.Dto.Responses;

public class MemberDto
{
    public Guid Id { get; set; }

    public string Email { get; set; }

    public ICollection<Guid> HeadOfFamilies { get; set; }

    public ICollection<Guid> Families { get; set; }
}