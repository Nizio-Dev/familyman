using FamilyMan.API.Authorization.Resources;
using FamilyMan.Core.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace FamilyMan.API.Authorization;

public class MemberOwnerOnlyHandler : AuthorizationHandler<MemberOwnerOnlyRequirement, Member>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, MemberOwnerOnlyRequirement requirement, 
        Member member)
    {

        var memberOwner = member.Id.ToString();
        var currentUserId = context.User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

        if (memberOwner == currentUserId)
        {
            context.Succeed(requirement);
        }

        return Task.CompletedTask;
    }
}


