using Partner.Application.Features.Merchants.Commands;
using Microsoft.Extensions.DependencyInjection; 

namespace Merchant.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCqrs(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreatePartnerCommand).Assembly));

            return services;
        }
    }
}
