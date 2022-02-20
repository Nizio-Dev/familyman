using FamilyMan.Domain.Models;
using FamilyMan.Infrastructure.Interfaces;

namespace FamilyMan.Application.Interfaces;

public interface IMemberRepository : IGenericRepository<Member>
{
    public Task<Member> GetByEmailAsync(string email);
}

