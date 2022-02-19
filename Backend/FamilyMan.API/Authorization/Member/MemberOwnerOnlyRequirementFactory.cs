using FamilyMan.Application.Interfaces;

namespace FamilyMan.API.Authorization.Resources;

public class RequirementFactory : IRequirementFactory
{
    public IMemberOwnerOnlyRequirement Create()
    {
        return new MemberOwnerOnlyRequirement();
    }
}

