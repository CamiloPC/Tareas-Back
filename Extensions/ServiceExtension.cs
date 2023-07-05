using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using TaskApi.Entities;
using TaskApi.Entities.ConfigModels;
using TaskApi.Infrastructure.Repositories;
using TaskApi.Infrastructure.Services;
using TaskApi.Logger;
using System.Text;

namespace TaskApi.Extensions;
public static class ServiceExtension
{
    public static IServiceCollection AddAppServices(this IServiceCollection services,
        ConfigurationManager configuration, IWebHostEnvironment environment)
    {
        services.AddSingleton<ILoggerManager, LoggerManager>();
        services.AddDbContext<Infrastructure.Repositories.ApplicationContext>(
            opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("SQLServerConnection"));
                //opt.UseSqlServer(environment.IsDevelopment() ? configuration.GetConnectionString("NeoRegenWebDbSQL") : Environment.GetEnvironmentVariable("NeoRegenWebDbSQL"));
            });

        services.AddScoped<IRepositoryManager, RepositoryManager>();
        services.AddScoped<IServiceManager, ServiceManager>();
        services.AddCors(options =>
        {
            options.AddPolicy("CorsPolicy", builder =>
            builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader()
            .WithExposedHeaders("X-Pagination"));
        });



        services.AddIdentity<User, IdentityRole>(o =>
        {
            o.Password.RequireDigit = true;
            o.Password.RequireLowercase = true;
            o.Password.RequireUppercase = true;
            o.Password.RequireNonAlphanumeric = false;
            o.Password.RequiredLength = 8;
            o.User.RequireUniqueEmail = true;
        })
        .AddEntityFrameworkStores<ApplicationContext>()
        .AddDefaultTokenProviders();

        //Jwt
        var jwtConfiguration = new JwtConfiguration();
        configuration.Bind(jwtConfiguration.Section, jwtConfiguration);

        //
        services.Configure<JwtConfiguration>(configuration.GetSection("JwtSettings"));

        var secretKey = jwtConfiguration.Secret;
        //var secretKey = environment.IsDevelopment()
        //    ? jwtConfiguration.Secret : Environment.GetEnvironmentVariable("SECRET");

        services.AddAuthentication(opt =>
        {
            opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = jwtConfiguration.ValidIssuer,
                ValidAudience = jwtConfiguration.ValidAudience,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
            };
        });
        return services;
    }
}
