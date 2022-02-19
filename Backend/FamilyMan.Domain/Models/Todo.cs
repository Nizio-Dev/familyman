﻿using FamilyMan.Core.Enums;

namespace FamilyMan.Core.Models;

public class Todo
{
    public Guid Id { get; set; }
    public Member Owner { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public TodoPriority Priority { get; set; }
    public bool IsFinished { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime? CompletionDate { get; set; } = null;
}
