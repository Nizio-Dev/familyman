using FamilyMan.Application.Interfaces;

namespace FamilyMan.API.Authorization.Resources;

public class MemberOwnerOnlyRequirementFactory : IMemberOwnerOnlyRequirementFactory
{
    public IMemberOwnerOnlyRequirement Create()
    {
        return new MemberOwnerOnlyRequirement();
    }
}

