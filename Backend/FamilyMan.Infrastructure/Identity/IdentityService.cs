using FamilyMan.Application.Interfaces;
using FamilyMan.Domain.Models;
using Microsoft.AspNetCore.Identity;

namespace FamilyMan.Infrastructure.Identity;

public class IdentityService : IIdentityService
{
    private readonly UserManager<ApplicationUser> _userManager;

    public IdentityService(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<bool>  AddUserAsync(Guid id, string email, string password)
    {
        var user = new ApplicationUser
        {
            Id = id.ToString(),
            UserName = email,
            Email = email
        };

        var addUser = await _userManager.CreateAsync(user, password);

        if (addUser.Succeeded)
        {
            return true;
        }

        return false;
    }

    public async Task<bool> RemoveUserAsync(Member member)
    {

        var user = await _userManager.FindByIdAsync(member.Id.ToString());

        var removeUser = await _userManager.DeleteAsync(user);

        if (removeUser.Succeeded)
        {
            return true;
        }

        return false;
    }
}