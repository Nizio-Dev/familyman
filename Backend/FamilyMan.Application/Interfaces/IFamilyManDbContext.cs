using FamilyMan.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace FamilyMan.Application.Interfaces;

public interface IFamilyManDbContext : IDisposable
{
    public DbSet<Member> Members { get; set; }
    public DbSet<Family> Families { get; set; }
    public DbSet<Todo> Todos { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}