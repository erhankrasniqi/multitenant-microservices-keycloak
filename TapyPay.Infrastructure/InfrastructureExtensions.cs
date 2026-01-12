using TapyPay.Infrastructure.Contracts.DistributedMessageBroker;
using TapyPay.Infrastructure.MessageBroker.Configuration;
using TapyPay.Infrastructure.MessageBroker;
using Microsoft.Extensions.DependencyInjection;

namespace TapyPay.Infrastructure
{
    public static class InfrastructureExtensions
    {
        public static IServiceCollection AddRabbitMq(this IServiceCollection services, RabbitMqSettings settings)
        {
            services.AddScoped<IRabbitMqConnectionFactory, RabbitMqConnectionFactory>();
            services.AddScoped<IMessageBroker>(s => new RabbitMqMessageBroker(settings,
                s.GetService<IRabbitMqConnectionFactory>()));

            return services;
        }
    }
}
