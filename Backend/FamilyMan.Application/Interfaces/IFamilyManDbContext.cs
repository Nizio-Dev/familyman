using FamilyMan.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace FamilyMan.Application.Interfaces;

public interface IFamilyManDbContext
{
    public DbSet<Member> Members { get; set; }
    public DbSet<Family> Families { get; set; }
    public DbSet<Todo> Todos { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    DbSet<TEntity> Set<TEntity> () where TEntity : class;
}