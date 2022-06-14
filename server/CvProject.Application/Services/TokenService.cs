using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CvProject.Application.Configuration;
using CvProject.Application.Contracts;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace CvProject.Application.Services;

public class TokenService : ITokenService
{
    private readonly JwtConfiguration _config;
    
    public TokenService(IOptions<JwtConfiguration> jwtConfigOptions)
    {
        _config = jwtConfigOptions.Value;
    }

    public TokenInfo GenerateToken(List<Claim> claims)
    {
        var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.Secret));

        var token = new JwtSecurityToken(
            issuer: _config.ValidIssuer,
            audience: _config.ValidAudience,
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
