using FamilyMan.Domain.Models;

namespace FamilyMan.Application.Interfaces;

public interface IIdentityService
{
    public Task<bool> AddUserAsync(Guid id, string email, string password);
    public Task<bool> RemoveUserAsync(Member member);
}