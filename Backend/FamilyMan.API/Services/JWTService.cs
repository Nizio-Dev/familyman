using FamilyMan.API.Interfaces;
using FamilyMan.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FamilyMan.API.Services;
public class JWTService : IJWTService 
{
    private readonly string _secureKey;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IConfiguration _configuration;

    public JWTService(IConfiguration configuration, 
        UserManager<ApplicationUser> userManager)
    {
        _secureKey = configuration.GetSection("JwtConfig:Secret").Value;
        _userManager = userManager;
        _configuration = configuration;
    }

    public async Task<string> GenerateAsync(ApplicationUser appUser) {

        var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_secureKey));
        var credentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

        var expiration = DateTime.UtcNow.AddMinutes(5);

        var user = await _userManager.FindByIdAsync(appUser.Id);
        var claims = new List<Claim>()
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id),
            new Claim(ClaimTypes.Name, user.Email),
            new Claim(ClaimTypes.Email, user.Email)
        };
     
        var securityToken = new JwtSecurityToken(
            issuer: _configuration.GetSection("JwtConfig:Issuer").Value,
            audience: _configuration.GetSection("JwtConfig:Audience").Value,
            claims: claims,
            expires: expiration,
            signingCredentials: credentials
            );

        return new JwtSecurityTokenHandler().WriteToken(securityToken);
    }
}