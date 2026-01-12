
using Microsoft.Extensions.DependencyInjection;
using Payout.Application.Features.Merchants.Commands;

namespace Payment.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCqrs(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreatePayoutCommand).Assembly));

            return services;
        }
    }
}
