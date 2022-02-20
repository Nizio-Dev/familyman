using FamilyMan.Application.Interfaces;
using FamilyMan.Infrastructure.Identity;
using FamilyMan.Infrastructure.Persistence;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FamilyMan.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {

        // Database
        services.AddScoped<IFamilyManDbContext>(provider => provider.GetRequiredService<FamilyManDbContext>());
        services.AddDbContext<FamilyManDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"))
        );
        
        // Identity
        services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<FamilyManDbContext>();

        // Identity password requirements
        services.Configure<IdentityOptions>(options => {
            options.Password.RequireDigit = false;
            options.Password.RequiredLength = 0;
            options.Password.RequireLowercase = false;
            options.Password.RequireUppercase = false;
            options.Password.RequiredUniqueChars = 0;
            options.Password.RequireNonAlphanumeric = false;
        });

        // Services
        services.AddTransient<IIdentityService, IdentityService>();

 
        return services;
    }
}