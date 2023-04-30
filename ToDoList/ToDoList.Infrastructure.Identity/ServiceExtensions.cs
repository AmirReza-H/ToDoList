using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.Text;
using ToDoList.Application.Interfaces.Identity;
using ToDoList.Domain.Settings;
using ToDoList.Infrastructure.Identity.Contexts;
using ToDoList.Infrastructure.Identity.Models;
using ToDoList.Infrastructure.Identity.Seeds;
using ToDoList.Infrastructure.Identity.Services;

namespace ToDoList.Infrastructure.Identity
{
    public static class ServicesInjection
    {
        public async static void AddJwt(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<IdentityContext>().AddDefaultTokenProviders();

        services.Configure<JWTSettings>(configuration.GetSection("JWTSettings"));
        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
            .AddJwtBearer(o =>
            {
                o.RequireHttpsMetadata = false;
                o.SaveToken = false;
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero,
                    ValidIssuer = configuration["JWTSettings:Issuer"],
                    ValidAudience = configuration["JWTSettings:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWTSettings:Key"]))
                };
                o.Events = new JwtBearerEvents()
                {
                    OnForbidden = context =>
                    {
                        context.Response.StatusCode = 403;
                        context.Response.ContentType = "application/json";
                        var result = JsonConvert.SerializeObject("You are not authorized to access this resource");
                        return context.Response.WriteAsync(result);
                    },
                };
            });

    }
    public static void AddIdentityInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {

        services.AddDbContext<IdentityContext>(options =>
        options.UseSqlServer(
            configuration.GetConnectionString("IdentityConnection"),
            b => b.MigrationsAssembly(typeof(IdentityContext).Assembly.FullName)));


            services.AddHostedService<IdentityRequirementSeed>();
            services.AddScoped<IAccountService, AccountService>();

    }
}
}
