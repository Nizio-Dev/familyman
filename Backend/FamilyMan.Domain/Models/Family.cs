namespace FamilyMan.Domain.Models;

public class Family
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Member Head { get; set; }
    public List<Member> Members { get; set; }
}

