namespace FamilyMan.Application.Dto.Responses;

public class FamilyDto
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public Guid Head { get; set; }

    public ICollection<Guid> Members { get; set; }
}