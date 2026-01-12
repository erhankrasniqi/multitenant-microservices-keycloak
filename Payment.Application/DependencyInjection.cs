using Payment.Application.Features.Merchants.Commands;
using Microsoft.Extensions.DependencyInjection; 

namespace Payment.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCqrs(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreatePaymentCommand).Assembly));

            return services;
        }
    }
}
