namespace FamilyMan.Domain.Models;

public class Family
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Member Head { get; set; }
    public List<Member> Members { get; set; }

    internal Family()
    {

    }

    public Family(string name, Member currentUser)
    {
        Id = Guid.NewGuid();
        Name = name;
        Head = currentUser;
        Members = new List<Member>{currentUser};
    }

    public void AddMember(Member member)
    {
        Members.Add(member);
    }

    public void MakeHead(Member member)
    {
        if (Members.Contains(member)){
            Head = member;
            return;
        }
        throw new InvalidOperationException("Member is not in the family.");
    }
}

