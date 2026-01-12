using Infrastructure.Messaging.Configuration;
using Infrastructure.Messaging.Interfaces;
using Infrastructure.Messaging.Publisher; 
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Messaging.Extensions;

public static class MessagingServiceExtensions
{
    public static IServiceCollection AddMessaging(this IServiceCollection services, IConfiguration configuration)
    {
        //services.Configure<RabbitMqOptions>(configuration.GetSection("RabbitMq"));
        services.AddSingleton<IEventPublisher, UserRegisteredPublisher>(); // Register publisher
        return services;
    }
}
