using System.Security.Claims;
using CvProject.Application.Contracts;

namespace CvProject.Application.Services;

public interface ITokenService
{
    TokenInfo GenerateToken(List<Claim> claims);
}