 
using UserManagement.API.Middlewares;
using UserManagement.API; 

var builder = WebApplication.CreateBuilder(args);

string corsPolicy = "TapyPayPolicy";

builder.Services.AddCorsInApplication(corsPolicy);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerWithJwtSupport();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();
builder.Services.AddExceptionHandler<CustomExceptionHandler>();
builder.Services.AddProblemDetails();
builder.Services.InitializeServices(builder.Configuration); 
builder.Services.AddAuthenticationKeyCloak();

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


