using FamilyMan.Infrastructure.Identity;

namespace FamilyMan.API.Interfaces;

public interface IJWTService
{
    public Task<string> GenerateAsync(ApplicationUser appUser);
}