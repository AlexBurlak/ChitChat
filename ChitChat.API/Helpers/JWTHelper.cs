using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ChitChat.Core.Entities;
using Microsoft.IdentityModel.Tokens;

namespace ChitChat.API.Helpers;

public interface IJWTHelper
{
    public string GetToken(User user);
}

public class JWTHelper : IJWTHelper
{
    private readonly IConfiguration _configuration;

    public JWTHelper(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string GetToken(User user)
    {
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, _configuration["JWT:Subject"]),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString(CultureInfo.InvariantCulture)),
            new Claim("UserId", user.Id.ToString()),
            new Claim("UserName", user.UserName),
            new Claim("Email", user.Email)
        };
            
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));
        var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var token = new JwtSecurityToken(
            _configuration["JWT:ValidIssuer"],
            _configuration["JWT:ValidAudience"],
            claims,
            expires: DateTime.UtcNow.AddHours(1),
            signingCredentials: signIn
        );
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}