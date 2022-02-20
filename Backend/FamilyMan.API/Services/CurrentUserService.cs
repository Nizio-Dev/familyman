using FamilyMan.Application.Interfaces;
using FamilyMan.Domain.Models;
using System.Security.Claims;

namespace FamilyMan.API.Services;

public class CurrentUserService : ICurrentUserService
{

    private readonly IFamilyManDbContext _context;
    private readonly ClaimsPrincipal _currentUser;

    public CurrentUserService(IHttpContextAccessor contextAccessor, IFamilyManDbContext context)
    {
        _context = context;
        _currentUser = contextAccessor.HttpContext.User;
    }


    public Member? Member => _context.Members.FirstOrDefault(
        m => m.Email == _currentUser.Claims.FirstOrDefault( c => c.Type == ClaimTypes.NameIdentifier).Value);


    public ClaimsPrincipal MemberIdentity => _currentUser;
}

