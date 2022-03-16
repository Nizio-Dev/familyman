namespace FamilyMan.Domain.Models;

public class Member
{
    public Guid Id { get; set; }

    public bool IsConfirmed { get; set; }

    public string Email { get; set; }

    public ICollection<Family> Families { get; set; }

    public ICollection<Family> HeadOfamilies { get; set; }

    public ICollection<Todo> Todos { get; set; }

    public Member(string email)
    {
        Id = Guid.NewGuid();
        IsConfirmed = false;
        Email = email;
        Families = null;
        HeadOfamilies = null;
        Todos = null;
    }

    internal Member() {}

    public void Confirm()
    {
        IsConfirmed = true;
    }
}