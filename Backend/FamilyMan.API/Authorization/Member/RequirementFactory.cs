using FamilyMan.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace FamilyMan.API.Authorization.Resources;

public class RequirementFactory : IRequirementFactory
{
    public IAuthorizationRequirement Create(string requirementType)
    {
        switch (requirementType)
        {
            case "MemberOwnerOnlyRequirement":
                return new MemberOwnerOnlyRequirement();


                default:
                    return null;

        }
    }
}

