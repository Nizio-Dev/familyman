using FamilyMan.Application.Interfaces;
using FamilyMan.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FamilyMan.Infrastructure.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{

    internal DbSet<T> dbSet;
    protected IFamilyManDbContext dbContext;

    public GenericRepository(IFamilyManDbContext dbContext)
    {
        this.dbContext = dbContext;
        dbSet = dbContext.Set<T>();
    }

    public virtual void Add(T entity)
    {
        dbSet.Add(entity);
    }

    public virtual void Delete(T entity)
    {
        dbSet.Remove(entity);
    }

    public async Task<T> GetByIdAsync(string id)
    {
        throw new NotImplementedException();
    }
}