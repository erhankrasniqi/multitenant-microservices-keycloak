 
using UserManagement.API.Middlewares;
using UserManagement.API;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Infrastructure.Messaging.Extensions;

var builder = WebApplication.CreateBuilder(args);

string corsPolicy = "TapyPayPolicy";

builder.Services.AddCorsInApplication(corsPolicy);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();
builder.Services.AddExceptionHandler<CustomExceptionHandler>();
builder.Services.AddProblemDetails();
builder.Services.InitializeServices(builder.Configuration);
builder.Services.AddMessaging(builder.Configuration);


builder.Services.AddSwaggerGen(options =>
{ 
    options.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Description = "Vendos tokenin tënd këtu (pa 'Bearer ')"
    });

    options.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
    {
        {
            new Microsoft.OpenApi.Models.OpenApiSecurityScheme
            {
                Reference = new Microsoft.OpenApi.Models.OpenApiReference
                {
                    Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});



builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
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



builder.Services.AddAuthorization();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(corsPolicy);

app.UseExceptionHandler();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();


