using FamilyMan.Application.Interfaces;
using FamilyMan.Domain.Models;
using System.Security.Claims;

namespace FamilyMan.API.Services;

public class CurrentUserService : ICurrentUserService
{

    private readonly IFamilyManDbContext _context;
    private readonly ClaimsPrincipal _currentUser;
    private readonly string _currentUsersId;

    public CurrentUserService(IHttpContextAccessor contextAccessor, IFamilyManDbContext context)
    {
        _context = context;
        _currentUser = contextAccessor.HttpContext.User;
        _currentUsersId = _currentUser.Claims.FirstOrDefault( c => c.Type == ClaimTypes.NameIdentifier).Value;
    }


    public Member? Member => _context.Members.FirstOrDefault(
        m => m.Id.ToString() == _currentUsersId);


    public ClaimsPrincipal MemberIdentity => _currentUser;
}

