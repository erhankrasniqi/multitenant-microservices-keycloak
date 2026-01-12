using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using TapyPay.Infrastructure.MessageBroker.Configuration;

namespace TapyPay.Infrastructure.MessageBroker
{
    public interface IRabbitMqConnectionFactory
    {
        IConnection CreateConnection(RabbitMqSettings settings);
        AsyncEventingBasicConsumer CreateConsumer(IModel channel);
    }
}
