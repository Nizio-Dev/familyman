
using Microsoft.AspNetCore.Authorization;

namespace FamilyMan.Application.Interfaces;

public interface IRequirementFactory
{
    IAuthorizationRequirement Create(string requirementType);
}

