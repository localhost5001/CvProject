using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CvProject.Application.Contracts;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace CvProject.Application.Services;

public class TokenService : ITokenService
{
    private readonly IConfiguration _configuration;
    
    public TokenService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public TokenInfo GenerateToken(List<Claim> claims)
    {
        var secret = _configuration["JWT:Secret"];
        var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));

        var token = new JwtSecurityToken(
            issuer: _configuration["JWT:ValidIssuer"],
            audience: _configuration["JWT:ValidAudience"],
            expires: DateTime.Now.AddHours(3),
            claims: claims,
            signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
        );
        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenStr = tokenHandler.WriteToken(token);

        if (tokenStr == null) 
        {
            throw new Exception("Token generation error");
        }

        return new TokenInfo(tokenStr, token.ValidTo);
    }
}
