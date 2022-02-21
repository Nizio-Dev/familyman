using FamilyMan.API.Authorization;
using FamilyMan.API.Interfaces;
using FamilyMan.API.Services;
using FamilyMan.Application;
using FamilyMan.Application.Interfaces;
using FamilyMan.Infrastructure;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container / Ignore Json reference cycles.
builder.Services.AddControllers().AddFluentValidation().AddJsonOptions(x => 
x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

// Add custom services
builder.Services.AddScoped<IJWTService, JWTService>();
builder.Services.AddScoped<ICurrentUserService, CurrentUserService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Fix async action trims
builder.Services.AddMvc(options =>
{
    options.SuppressAsyncSuffixInActionNames = false;
});

// Application Layer
builder.Services.AddApplication();

// Infrastructure Layer
builder.Services.AddInfrastructure(builder.Configuration);

// Add authentication
builder.Services.AddAuthentication(options => 
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options => 
{
    options.TokenValidationParameters = new TokenValidationParameters() {
        ValidateIssuer = true,
        ValidIssuer = "https://localhost:7285",
        ValidateAudience = true,
        ValidAudience = "https://localhost:3000",
        ValidateLifetime = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtConfig:secret"]))
    };
    options.Events = new JwtBearerEvents 
    {
        OnMessageReceived = context => 
        {
            context.Token = context.Request.Cookies["jwt"];
            return Task.CompletedTask;
        }
    };
});

// Add authorization
builder.Services.AddScoped<IAuthorizationHandler, MemberOwnerOnlyHandler>();

// Setip authorization
builder.Services.AddAuthorization(options =>
    options.AddPolicy(Policies.MemberFamily, policy => policy.Requirements.Add(new MemberOwnerOnlyRequirement()))
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseCors();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
