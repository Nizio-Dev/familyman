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

    internal Todo()
    {

    }

    public Todo(string name, string description, Member currentUser, TodoPriority priority,
        DateTime? plannedCompletionDate)
    {
        Id = Guid.NewGuid();
        Owner = currentUser;
        Name = name;
        Description = description;
        Priority = priority;
        IsFinished = false;
        CreationDate = DateTime.UtcNow;
        PlannedCompletionDate = plannedCompletionDate;
        CompletionDate = null;
    }

    public void FinishTask()
    {
        IsFinished = true;
        CompletionDate = DateTime.UtcNow;
    }
}

