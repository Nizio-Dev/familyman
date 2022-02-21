using FamilyMan.Application.Interfaces;
using FamilyMan.Domain.Models;
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
            .HasMany(m => m.Families)
            .WithMany(f => f.Members);

        builder.Entity<Member>()
            .HasMany(m => m.HeadOfamilies)
            .WithOne(f => f.Head);

        builder.Entity<Member>()
            .HasMany(m => m.Todos)
            .WithOne(t => t.Owner);


    }
}

