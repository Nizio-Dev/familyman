namespace FamilyMan.Domain.Models;

public class Member
{
    public Guid Id { get; set; }
    public bool IsConfirmed { get; set; }
    public string Email { get; set; }
    public List<Family> Families { get; set; }
    public List<Family> HeadOFamilies { get; set; }
    public List<Todo> Todos { get; set; }

    internal Member()
    {

    }

    public Member(string email)
    {
        Id = Guid.NewGuid();
        IsConfirmed = false;
        Email = email;
        Families = null;
        HeadOFamilies = null;
        Todos = null;
    }

    public void Confirm()
    {
        IsConfirmed = true;
    }
}

