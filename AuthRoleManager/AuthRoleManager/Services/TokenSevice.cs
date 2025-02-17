using AuthRoleManager.Domain.Enum;
using AuthRoleManager.Services.Interface;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AuthRoleManager.Services;

public class TokenSevice : ITokenService
{
    private IConfiguration _configuration;
    public TokenSevice(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task<string> GetTokenAsync(string email, string password, Role role)
    {
        string key = _configuration.GetSection("Authentication")["SecurityKey"];
        string issuer = _configuration.GetSection("Authentication")["Issuer"];
        string audience = _configuration.GetSection("Authentication")["Audience"];
        int expiresInMinutes = _configuration.GetSection("Authentication").GetValue<int>("ExpireAtInMinutes");

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claims = new List<Claim>()
        {
            new Claim(ClaimTypes.Email,email),
            new Claim("password",password),
            new Claim(ClaimTypes.Role,role.ToString())
        };

        var token = new JwtSecurityToken(
            claims: claims,
            issuer: issuer,
            audience: audience,
            expires: DateTime.Now.AddMinutes(expiresInMinutes),
            signingCredentials: credentials
        );
        return new JwtSecurityTokenHandler().WriteToken(token);

    }
}
