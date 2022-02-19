﻿using FamilyMan.Core.Enums;
using FamilyMan.Core.Models;

namespace FamilyMan.Application.Dto.Responses;

public class TodoDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public TodoPriority Priority { get; set; }
    public Member Owner { get; set; }
    public DateTime CompletionDate { get; set; }
}