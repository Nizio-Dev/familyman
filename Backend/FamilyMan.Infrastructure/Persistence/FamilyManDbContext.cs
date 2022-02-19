using FamilyMan.Application.Interfaces;
using FamilyMan.Core.Models;
using FamilyMan.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FamilyMan.Infrastructure.Persistence;

public class FamilyManDbContext : IdentityDbContext<ApplicationUser>, IFamilyManDbContext
{
    public FamilyManDbContext(DbContextOptions<FamilyManDbContext> options) : base(options){}

    public DbSet<Member> Members { get; set; }
    public DbSet<Family> Families { get; set; }
    public DbSet<Todo> Todos { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Member>()
            .HasMany(f => f.Families)
            .WithMany(m => m.Members);

        builder.Entity<Member>()
            .HasMany(h => h.HeadOFamilies)
            .WithOne(hof => hof.Head);

        builder.Entity<Member>()
            .HasMany(t => t.Todos)
            .WithOne(o => o.Owner);

    }
}

