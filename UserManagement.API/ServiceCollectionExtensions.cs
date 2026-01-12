using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using TapyPay.Infrastructure.MessageBroker.Configuration;
using UserManagement.Application;
using UserManagement.Infrastructure;
namespace UserManagement.API
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

            string rabbitMqSection = "RabbitMqConfiguration:";
            string host = configuration.GetSection($"{rabbitMqSection}Host").Value;
            int port = int.Parse(configuration.GetSection($"{rabbitMqSection}Port").Value);
            string username = configuration.GetSection($"{rabbitMqSection}Username").Value;
            string password = configuration.GetSection($"{rabbitMqSection}Password").Value;
            string clientProvidedName = configuration.GetSection($"{rabbitMqSection}ClientProvidedName").Value;
            string virtualHost = configuration.GetSection($"{rabbitMqSection}VirtualHost").Value;
            RabbitMqSettings rabbitMqSettings = new(host, port, username, password, clientProvidedName, virtualHost);

            services.RegisterDbContext(dbConnectionString);
            services.RegisterRepositories();
            services.RegisterMessageBrokerAndNotifications(rabbitMqSettings);
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
                options.Authority = "http://localhost:8080/realms/master";
                options.RequireHttpsMetadata = false; // Çaktivizo kërkesën për HTTPS gjatë zhvillimit

                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = "http://localhost:8080/realms/master",
                    ValidAudiences = new[] { "master-realm", "TapyPay-realm", "account", "user-management-api" },
                    ValidateAudience = true,
                    ValidateIssuer = true
                };


                options.Events = new JwtBearerEvents
                {
                    OnAuthenticationFailed = context =>
                    {
                        Console.WriteLine("AUTHENTICATION FAILED:");
                        Console.WriteLine(context.Exception.Message);
                        return Task.CompletedTask;
                    },
                    OnTokenValidated = context =>
                    {
                        Console.WriteLine("TOKEN VALIDATED:");
                        Console.WriteLine($"User: {context.Principal.Identity?.Name}");
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
