using FamilyMan.Application.Interfaces;
using FamilyMan.Domain.Models;
using FamilyMan.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FamilyMan.Infrastructure.Repositories;

public class TodoRepository : GenericRepository<Todo>, ITodoRepository
{
    public TodoRepository(IFamilyManDbContext dbContext) : base(dbContext)
    {
    }

    public Task<Todo> GetById(string id)
    {
        throw new NotImplementedException();
    }

}

