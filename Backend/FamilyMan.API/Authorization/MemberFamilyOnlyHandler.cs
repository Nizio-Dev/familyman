using FamilyMan.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace FamilyMan.API.Authorization;

public class MemberFamilyOnlyHandler : AuthorizationHandler<MemberFamilyOnlyRequirement, Member>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, MemberFamilyOnlyRequirement requirement, Member member)
    {
        var httpContext = context.Resource as HttpContext;

        var memberFamily = member.Id.ToString();
        var currentUserId = httpContext!.User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier).Value;

        if (memberFamily == currentUserId)
        {
            context.Succeed(requirement);
        }

        return Task.CompletedTask;
    }
}