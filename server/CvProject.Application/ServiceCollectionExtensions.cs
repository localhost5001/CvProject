using CvProject.Application.Configuration;
using CvProject.Application.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CvProject.Application;

public static class ServiceCollectionExtensions
{
    public static void AddAppServices(this IServiceCollection services) 
    {
        var envName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", false, true)
            .AddJsonFile($"appsettings.{envName}.json", true, true)
            .Build();

        services.Configure<JwtConfiguration>(configuration.GetSection("JWT"));

        services.AddDbContext<AppDbContext>();

        services
            .AddIdentity<IdentityUser, IdentityRole>()
            .AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders();

        services
            .AddAuthentication(options => {
                options.DefaultScheme = "Cookies"; 
            })
            .AddCookie("Cookies", options => {
                options.Cookie.Name = "auth_cookie";
                options.Cookie.SameSite = SameSiteMode.None;
                options.Events = new CookieAuthenticationEvents
                {
                    OnRedirectToLogin = redirectContext => {
                        redirectContext.HttpContext.Response.StatusCode = 401;
                        return Task.CompletedTask;
                    }
                };
            });
        
        services.AddScoped<ITokenService, TokenService>();
    }
}
