using Analytics.Application;
using Analytics.Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace Analytics.API
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCorsInApplication(this IServiceCollection services, string policyName)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(policyName, builder =>
                {
                    builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
                });
            });

            return services;
        }

        public static IServiceCollection InitializeServices(this IServiceCollection services, IConfiguration configuration)
        {
            string dbConnectionString = configuration.GetConnectionString("DbConnection");

            services.RegisterDbContext(dbConnectionString);
            services.RegisterRepositories();
            services.AddCqrs();

            return services;
        }

        public static IServiceCollection AddSwaggerWithJwtSupport(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Vendos tokenin tënd këtu (pa 'Bearer ')"
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }
                });
            });

            return services;
        }

        public static IServiceCollection AddAuthenticationKeyCloak(this IServiceCollection services)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;

                // Këtu vendos Authority default, por mund ta mbash bosh dhe ta menaxhosh vetë validation
                options.Authority = "http://localhost:8080/realms/master";

                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    // Nuk i vendos këtu statik, do i kontrollojmë më vonë
                };

                options.Events = new JwtBearerEvents
                {
                    OnTokenValidated = context =>
                    {
                        var issuer = context.SecurityToken.Issuer;
                        var audience = context.Principal.Claims.FirstOrDefault(c => c.Type == "aud")?.Value;

                        // Kontrollo në listën e tenantëve të aprovuara
                        var validIssuers = new List<string>
                        {
                    "http://localhost:8080/realms/tenant1",
                    "http://localhost:8080/realms/tenant2"
                            // ...shto sa dëshiron
                        };

                        var validAudiences = new List<string>
                        {
                    "tenant1-client",
                    "tenant2-client"
                            // ...shto sa dëshiron
                        };

                        if (!validIssuers.Contains(issuer) || !validAudiences.Contains(audience))
                        {
                            context.Fail("Invalid issuer or audience.");
                        }

                        // Sukses
                        return Task.CompletedTask;
                    },

                    OnAuthenticationFailed = context =>
                    {
                        Console.WriteLine("AUTHENTICATION FAILED:");
                        Console.WriteLine(context.Exception.Message);
                        return Task.CompletedTask;
                    },

                    OnChallenge = context =>
                    {
                        Console.WriteLine("AUTH CHALLENGE:");
                        Console.WriteLine(context.Error);
                        Console.WriteLine(context.ErrorDescription);
                        return Task.CompletedTask;
                    }
                };
            });

            return services;
        }

    }
}
