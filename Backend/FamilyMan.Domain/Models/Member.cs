namespace FamilyMan.Domain.Models;

public class Member
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public List<Family> Families { get; set; }
    public List<Family> HeadOFamilies { get; set; }
    public List<Todo> Todos { get; set; }
}

