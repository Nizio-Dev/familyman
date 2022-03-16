using FamilyMan.Domain.Models;
using System.Security.Claims;

namespace FamilyMan.Application.Interfaces;

public interface ICurrentUserService
{
    Member? Member { get; }

    ClaimsPrincipal MemberIdentity { get; }
}

