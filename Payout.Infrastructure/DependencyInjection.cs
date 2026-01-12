using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Payment.Infrastructure.Repositories;
using Payout.Infrastructure.Contracts;
using Payout.Infrastructure.Database;
using Payout.Infrastructure.Repositories;
using System.Reflection;   

namespace Payout.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection RegisterDbContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<PayoutDbContext>(options => options.UseNpgsql(connectionString));

            return services;
        }

        public static IServiceCollection RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IPayoutRepository, PayoutRepository>();

            AutoRegisterRepositories(services);

            return services;
        }

        private static void AutoRegisterRepositories(IServiceCollection services)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            Type[] types = assembly.GetTypes();
            IEnumerable<Type> repositoryInterfaces = types.Where(t => t.IsInterface && t.Name.ToLower().Trim().EndsWith("repository"));

            if (repositoryInterfaces.Any())
            {
                foreach (Type repositoryInterface in repositoryInterfaces)
                {
                    Type implementationType = types.FirstOrDefault(t =>
                        t.IsClass
                        && !t.IsAbstract
                        && !t.IsInterface
                        && repositoryInterface.IsAssignableFrom(t));

                    if (implementationType != null)
                    {
                        services.AddScoped(repositoryInterface, implementationType);
                    }
                }
            }
        }
    }
}