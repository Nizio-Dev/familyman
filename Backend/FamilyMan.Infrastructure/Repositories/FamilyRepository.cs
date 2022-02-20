using FamilyMan.Application.Interfaces;
using FamilyMan.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace FamilyMan.Infrastructure.Repositories;

public class FamilyRepository : GenericRepository<Family>,  IFamilyRepository
{
    public FamilyRepository(IFamilyManDbContext dbContext) : base(dbContext)
    {
    }

    public Task<Family> GetById(string id)
    {
        throw new NotImplementedException();
    }

}

