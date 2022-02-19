using System.Reflection;
using FamilyMan.Application.Interfaces;
using FamilyMan.Application.Services;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace FamilyMan.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {

        services.AddScoped<IMemberService, MemberService>();
        services.AddScoped<IFamilyService, FamilyService>();
        services.AddScoped<ITodoService, TodoService>();
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        return services;
    }
}