using System.Text;
using CvProject.Application.Configuration;
using CvProject.Application.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

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
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options => {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters 
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = "*",
                    ValidIssuer = "*",
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("secret"))
                };
            });
        
        services.AddScoped<ITokenService, TokenService>();
    }
}
