using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace CvProject.Application
{
    public static class ServiceCollectionExtensions
    {
        public static void AddAppServices(this IServiceCollection services) 
        {
            services
                .AddDbContext<AppDbContext>()
                .AddIdentity<IdentityUser, IdentityRole>()
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
        }
    }
}
