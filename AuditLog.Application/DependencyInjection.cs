 
using Microsoft.Extensions.DependencyInjection; 

namespace AuditLog.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCqrs(this IServiceCollection services)
        {
            //services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateAnaLyticsCommand).Assembly));

            return services;
        }
    }
}
