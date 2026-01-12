 
    using Microsoft.Extensions.Options;
    using RabbitMQ.Client;
    using System.Text;
    using System.Text.Json;
    using global::Infrastructure.Messaging.Configuration;
    using global::Infrastructure.Messaging.Interfaces;
    using Microsoft.EntityFrameworkCore.Metadata;

    namespace Infrastructure.Messaging.Publisher;

    public class UserRegisteredPublisher : IEventPublisher
    {
        private readonly RabbitMqOptions _options;
        private readonly IConnection _connection;
        private readonly IModel _channel;

        public UserRegisteredPublisher(IOptions<RabbitMqOptions> options)
        {
            _options = options.Value;
            var factory = new ConnectionFactory()
            {
                HostName = _options.HostName,
                UserName = _options.UserName,
                Password = _options.Password
            };

           // _connection = factory.CreateConnection();
           // _channel = _connection.CreateModel();

           // _channel.ExchangeDeclare(_options.ExchangeName, ExchangeType.Topic, durable: true);
        }

        public Task PublishAsync<T>(T @event, string routingKey)
        {
            var message = JsonSerializer.Serialize(@event);
            var body = Encoding.UTF8.GetBytes(message);

            //_channel.BasicPublish(
            //    exchange: _options.ExchangeName,
            //    routingKey: routingKey,
            //    basicProperties: null,
            //    body: body
            //);

            return Task.CompletedTask;
        }
    }

