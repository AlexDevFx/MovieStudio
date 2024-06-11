using System.Text;
using Mapster;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MovieStudio.Authorization;
using MovieStudio.Contacts.Users;
using MovieStudio.Core.Contracts;
using MovieStudio.Core.Movies;
using MovieStudio.Core.Users;
using MovieStudio.Data;
using MovieStudio.Infrastructure;
using MovieStudio.Users;

namespace MovieStudio.Extensions;

public static class DependencyExtensions
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddDbContextPool<MoviesDbContext>(opt =>
        {
            opt.UseSqlServer();
        });

        services.AddScoped<IMoviesRepository, MoviesDbContext>();
        services.AddScoped<IUserRepository, MoviesDbContext>();

        services.AddScoped<MoviesProvider>();
        services.AddScoped<MoviesManager>();
        services.AddScoped<MovieOperationsChecker>();

        services.AddSingleton<RolesGuard>();
        services.AddSingleton<IClockProvider, ClockProvider>();
        services.AddScoped<IAuthorizedUser, WebAuthorizedUser>();
    }

    public static void AddEntitiesMapping()
    {
        var typeAdapterConfig = TypeAdapterConfig.GlobalSettings;
        typeAdapterConfig.Apply(new EntityMapper());
    }
    
    public static void SetupAuthorization(this IServiceCollection services, ConfigurationManager configurationManager)
    {
        services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(opt =>
            {
                opt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = configurationManager["Auth:JwtIssuer"],
                    ValidateAudience = true,
                    ValidAudience = configurationManager["Auth:JwtAudience"],
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey
                        (Encoding.UTF8.GetBytes(configurationManager["Auth:AccessTokenSecurityKey"]))
                };
	
            });
        
        services.AddAuthorization(opt =>
        {
            opt.AddPolicy(WebAppConsts.PolicyNames.Actor,
                p => p.AddRequirements(new UserRoleRequirement(UserRoleType.Actor)));
            opt.AddPolicy(WebAppConsts.PolicyNames.Admin,
                p => p.AddRequirements(new UserRoleRequirement(UserRoleType.Admin)));
            opt.AddPolicy(WebAppConsts.PolicyNames.Director,
                p => p.AddRequirements(new UserRoleRequirement(UserRoleType.Director)));
            opt.AddPolicy(WebAppConsts.PolicyNames.Actor,
                p => p.AddRequirements(new UserRoleRequirement(UserRoleType.Actor)));
        });

        services.AddScoped<IAuthorizationHandler, UserAuthorizationHandler>();
    }
}