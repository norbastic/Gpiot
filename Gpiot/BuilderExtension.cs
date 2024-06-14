using System.Text;
using Gpiot.DB;
using Gpiot.Helpers;
using Gpiot.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

public static class BuilderExtension {
    public static void RegisterCustomDependencies(this WebApplicationBuilder builder) {
        builder.Services.AddSingleton<IGpioHandler, GpioHandler>();
        var connectionString = EnvVariableHelper.GetConnectionString(builder);
        builder.Services.AddDbContext<RpiDbContext>(
            options => options.UseNpgsql(connectionString)
        );
        var auth0Config = EnvVariableHelper.GetAuth0Config();

        builder.Services.AddAuthentication(options => {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(options => {
            options.Authority = $"https://{auth0Config.Domain}";
            options.Audience = auth0Config.Audience;
            options.TokenValidationParameters = new TokenValidationParameters {
                ValidIssuer = $"https://{auth0Config.Domain}",
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(auth0Config.ClientSecret)),
                ValidateIssuerSigningKey = true
            };

        });
        builder.Services.AddAuthorization();
    }    
}