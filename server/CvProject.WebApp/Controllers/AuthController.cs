using System.Security.Claims;
using CvProject.Application.Contracts;
using CvProject.Application.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CvProject.WebApp.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ITokenService _tokenService;
        private readonly ILogger<AuthController> _logger;
        
        public AuthController(
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager,
            ITokenService tokenService,
            ILogger<AuthController> logger)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _tokenService = tokenService;
            _logger = logger;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync(RegisterPayload payload) 
        {
            var userByEmail = await _userManager.FindByEmailAsync(payload.Email);
            var userByName = await _userManager.FindByNameAsync(payload.UserName);

            if (userByEmail != null || userByName != null)
            {
                return BadRequest("User already exists");
            }

            var user = new IdentityUser
            {
                UserName = payload.UserName,
                Email = payload.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
            };
            var res = await _userManager.CreateAsync(user, payload.Password);
            
            if (!res.Succeeded)
            {
                _logger.LogError(res.ToString());

                return BadRequest("Couldn't create user, please try again later");   
            }

            return Ok();
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginCookie(LoginPayload payload)
        {
            var user = await _userManager.FindByNameAsync(payload.UserName);
            var isPasswordCorrect = await _userManager.CheckPasswordAsync(user, payload.Password);

            if (user == null || !isPasswordCorrect) 
            {
                return Unauthorized();
            }

            var claimsIdentity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, user.UserName),
            }, "Cookies");

            var userRoles = await _userManager.GetRolesAsync(user);
            var roleClaims = userRoles.Select(role => new Claim(ClaimTypes.Role, role));
            claimsIdentity.AddClaims(roleClaims);

            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
            await Request.HttpContext.SignInAsync("Cookies", claimsPrincipal);

            return NoContent();
        }

        [HttpPost("logout")]
        [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return NoContent();
        }
    }
}
