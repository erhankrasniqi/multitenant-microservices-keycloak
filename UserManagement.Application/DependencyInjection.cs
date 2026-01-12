using Microsoft.Extensions.DependencyInjection;
using UserManagement.Application.Features.Users.Commands;

namespace UserManagement.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCqrs(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateUserCommand).Assembly));

            return services;
        }
    }
}
