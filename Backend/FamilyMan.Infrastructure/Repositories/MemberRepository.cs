using FamilyMan.Application.Interfaces;
using FamilyMan.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace FamilyMan.Infrastructure.Repositories;

public class MemberRepository : GenericRepository<Member>, IMemberRepository
{
    public MemberRepository(IFamilyManDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<Member> GetByEmailAsync(string email)
    {
        return await dbSet.FirstOrDefaultAsync(x => x.Email == email);
    }

    public async Task<Member> GetById(string id)
    {
        return await dbSet.FirstOrDefaultAsync(x => x.Id.ToString() == id);
    }
}

