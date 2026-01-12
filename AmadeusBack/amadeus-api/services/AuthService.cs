using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using amadeus_api.database.models;
using Microsoft.IdentityModel.Tokens;

namespace amadeus_api.services;

public class AuthService(IConfiguration config)
{
    private readonly IConfiguration _config = config;

    public string GenerateToken(User user, int expiredInHours = 2)
    {
        var claims = new[]
        {
            new Claim("userid", user.Id.ToString()),
            new Claim("email", user.Email),
            new Claim("username", user.Name ?? "No Name")
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"] ?? ""));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _config["Jwt:Issuer"],
            audience: _config["Jwt:Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddHours(expiredInHours),
            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
