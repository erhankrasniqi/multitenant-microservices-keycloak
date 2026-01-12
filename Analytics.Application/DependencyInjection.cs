using Analytics.Application.Features.Merchants.Commands;
using Microsoft.Extensions.DependencyInjection; 

namespace Analytics.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCqrs(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateAnaLyticsCommand).Assembly));

            return services;
        }
    }
}
