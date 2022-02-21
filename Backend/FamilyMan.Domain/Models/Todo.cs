using FamilyMan.Domain.Enums;

namespace FamilyMan.Domain.Models;

public class Todo
{
    public Guid Id { get; set; }
    public Member Owner { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public TodoPriority Priority { get; set; }
    public bool IsFinished { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime? PlannedCompletionDate { get; set; } = null;
    public DateTime? CompletionDate { get; set; } = null;
}

