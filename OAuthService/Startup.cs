using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using Abstraction;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace AuthServices
{
    public static class Startup
    {
        public static IServiceCollection AddAuthOServices(this IServiceCollection services, IConfiguration configuration)
        {
            string domain = $"https://{configuration["Auth0:Domain"]}/";
            services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.Authority = domain;
                    options.Audience = configuration["Auth0:Audience"];
                    // If the access token does not have a `sub` claim, `User.Identity.Name` will be `null`. Map it to a different claim by setting the NameClaimType below.
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        NameClaimType = ClaimTypes.NameIdentifier
                    };
                });


            services.AddAuthorization(options =>
            {
                options.AddPolicy("read", policy => policy.Requirements.Add(new HasScopeRequirement("read", domain)));
                options.AddPolicy("insert", policy => policy.Requirements.Add(new HasScopeRequirement("insert", domain)));
            });

            services.AddSingleton<IAuthService, AuthOService>();

            return services;
        }
    }
}
