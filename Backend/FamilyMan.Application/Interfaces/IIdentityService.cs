namespace FamilyMan.Application.Interfaces;

public interface IIdentityService
{
    public Task<bool> AddUserAsync(Guid id, string email, string password);
}