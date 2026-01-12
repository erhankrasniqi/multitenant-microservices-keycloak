using RabbitMQ.Client.Events;
using RabbitMQ.Client.Exceptions;
using RabbitMQ.Client;
using System.Threading;
using System;
using TapyPay.Infrastructure.Contracts.DistributedMessageBroker.Exceptions;
using TapyPay.Infrastructure.MessageBroker.Configuration;

namespace TapyPay.Infrastructure.MessageBroker
{
    public class RabbitMqConnectionFactory : IRabbitMqConnectionFactory
    {
        public IConnection CreateConnection(RabbitMqSettings settings)
        {
            if (settings is null)
            {
                return null;
            }

            ConnectionFactory connectionFactory = new()
            {
                HostName = settings.Host,
                Port = settings.Port,
                UserName = settings.Username,
                Password = settings.Password,
                ClientProvidedName = settings.ClientProvidedName,
                VirtualHost = settings.VirtualHost,
                AutomaticRecoveryEnabled = settings.AutomaticRecoveryEnabled,
                TopologyRecoveryEnabled = settings.TopologyRecoveryEnabled,
                RequestedConnectionTimeout = settings.RequestedConnectionTimeout,
                RequestedHeartbeat = settings.RequestedHeartbeat,
                DispatchConsumersAsync = settings.DispatchConsumersAsync
            };

            return (string.IsNullOrEmpty(settings.ClientProvidedName))
                ?
                CreateUnnamedConnection(settings, connectionFactory)
                :
                CreateNamedConnection(settings, connectionFactory);
        }

        public AsyncEventingBasicConsumer CreateConsumer(IModel channel)
        {
            return new AsyncEventingBasicConsumer(channel);
        }

        private IConnection CreateUnnamedConnection(RabbitMqSettings settings, ConnectionFactory connectionFactory)
        {
            return TryToCreateConnection(connectionFactory.CreateConnection,
                settings.InitialConnectionRetries,
                settings.InitialConnectionRetryTimeoutMilliseconds);
        }

        private IConnection CreateNamedConnection(RabbitMqSettings settings, ConnectionFactory connectionFactory)
        {
            return TryToCreateConnection(() =>
                connectionFactory.CreateConnection(settings.ClientProvidedName),
                settings.InitialConnectionRetries,
                settings.InitialConnectionRetryTimeoutMilliseconds);
        }

        private IConnection TryToCreateConnection(Func<IConnection> connection, int numberOfRetries, int timeoutMilliseconds)
        {
            ValidateArguments(numberOfRetries, timeoutMilliseconds);

            int attempts = 0;
            BrokerUnreachableException brokerUnreachableException = null;

            while (attempts < numberOfRetries)
            {
                try
                {
                    if (attempts > 0)
                    {
                        Thread.Sleep(timeoutMilliseconds);
                    }

                    return connection();
                }
                catch (BrokerUnreachableException exception)
                {
                    attempts++;

                    brokerUnreachableException = exception;
                }
            }

            string errorMessage = $"Could not establish an initial connection in {numberOfRetries} retries.";

            throw new InitialConnectionException(-1, errorMessage, brokerUnreachableException);
        }

        private void ValidateArguments(int numberOfRetries, int timeoutMilliseconds)
        {
            if (numberOfRetries < 1)
            {
                throw new ArgumentException("Number of retries should be a positive number.", nameof(numberOfRetries));
            }

            if (timeoutMilliseconds < 1)
            {
                throw new ArgumentException("Initial reconnection timeout should be a positive number.", nameof(timeoutMilliseconds));
            }
        }
    }
}
