using FamilyMan.Domain.Enums;

namespace FamilyMan.Application.Dto.Requests;

public class CreateTodoDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public TodoPriority Priority { get; set; }
    public DateTime CompletionDate { get; set; }
}

