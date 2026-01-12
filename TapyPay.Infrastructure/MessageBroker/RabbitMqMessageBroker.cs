using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TapyPay.Infrastructure.Common;
using TapyPay.Infrastructure.Contracts.DistributedMessageBroker;
using TapyPay.Infrastructure.Contracts.DistributedMessageBroker.Exceptions;
using TapyPay.Infrastructure.Contracts.DistributedMessageBroker.Models;
using TapyPay.Infrastructure.MessageBroker.Configuration;

namespace TapyPay.Infrastructure.MessageBroker
{
    public sealed class RabbitMqMessageBroker : IMessageBroker, IDisposable
    {
        private readonly RabbitMqSettings _rabbitMqSettings;
        private readonly IRabbitMqConnectionFactory _rabbitMqConnectionFactory;
        private readonly object _lock = new();

        private AsyncEventingBasicConsumer _consumer;
        private bool _consuming = false;
        private IEnumerable<string> _consumerTags = new List<string>();
        private Action<string> _action;

        public IConnection Connection { get; private set; }
        public IConnection ConsumingConnection { get; private set; }
        public IModel Channel { get; private set; }
        public IModel ConsumingChannel { get; private set; }

        public RabbitMqMessageBroker(RabbitMqSettings settings, IRabbitMqConnectionFactory rabbitMqConnectionFactory)
        {
            _rabbitMqSettings = settings;
            _rabbitMqConnectionFactory = rabbitMqConnectionFactory;

            ConfigureConnectionInfrastructure(_rabbitMqSettings);
        }

        public async Task PublishObject<T>(IDistributedMessage<T> distributedMessage, CancellationToken cancellationToken = default)
            where T : class
        {
            await Task.Run(() => PublishObjectToExchange<T>(distributedMessage), cancellationToken).ConfigureAwait(false);
        }

        public async Task PublishJson(IDistributedMessage distributedMessage, CancellationToken cancellationToken = default)
        {
            await Task.Run(() => PublishJsonToExchange(distributedMessage), cancellationToken).ConfigureAwait(false);
        }

        public async Task PublishString(IDistributedMessage distributedMessage, CancellationToken cancellationToken = default)
        {
            await Task.Run(() => PublishStringToExchange(distributedMessage), cancellationToken).ConfigureAwait(false);
        }

        public async Task SendObject<T>(IDistributedMessage<T> distributedMessage, CancellationToken cancellationToken = default)
            where T : class
        {
            await Task.Run(() => SendObjectToQueue<T>(distributedMessage), cancellationToken).ConfigureAwait(false);
        }

        public async Task SendJson(IDistributedMessage distributedMessage, CancellationToken cancellationToken = default)
        {
            await Task.Run(() => SendJsonToQueue(distributedMessage), cancellationToken).ConfigureAwait(false);
        }

        public async Task SendString(IDistributedMessage distributedMessage, CancellationToken cancellationToken = default)
        {
            await Task.Run(() => SendStringToQueue(distributedMessage), cancellationToken).ConfigureAwait(false);
        }

        public async Task StartConsuming(IConsumer consumer)
        {
            await Task.CompletedTask;

            EnsureConsumingChannelIsNotNull();
            ValidateConsumer(consumer);

            if (_consuming)
            {
                return;
            }

            _consumer.Received += ConsumerOnReceived;
            _consuming = true;
            _action = consumer.Action;
            IList<string> tags = new List<string>();

            foreach (string queue in consumer.Queues)
            {
                string tag = ConsumingChannel.BasicConsume(queue: queue, autoAck: false, consumer: _consumer);

                tags.Add(tag);
            }

            _consumerTags = tags;
        }

        public async Task StopConsuming()
        {
            await Task.CompletedTask;

            EnsureConsumingChannelIsNotNull();

            if (!_consuming)
            {
                return;
            }

            _consumer.Received -= ConsumerOnReceived;
            _consuming = false;

            foreach (string tag in _consumerTags)
            {
                ConsumingChannel.BasicCancel(tag);
            }
        }

        public void Disconnect()
        {
            Dispose();
        }

        public void Dispose()
        {
            if (Connection != null)
            {
                Connection.CallbackException -= HandleConnectionCallbackException;

                if (Connection is IAutorecoveringConnection connection)
                {
                    connection.ConnectionRecoveryError -= HandleConnectionRecoveryError;
                }
            }

            if (ConsumingConnection != null)
            {
                ConsumingConnection.CallbackException -= HandleConnectionCallbackException;

                if (ConsumingConnection is IAutorecoveringConnection consumingConnection)
                {
                    consumingConnection.ConnectionRecoveryError -= HandleConnectionRecoveryError;
                }
            }

            if (Channel != null)
            {
                Channel.CallbackException -= HandleChannelCallbackException;
                Channel.BasicRecoverOk -= HandleChannelBasicRecoverOk;
            }

            if (ConsumingChannel != null)
            {
                ConsumingChannel.CallbackException -= HandleChannelCallbackException;
                ConsumingChannel.BasicRecoverOk -= HandleChannelBasicRecoverOk;
            }

            if (Channel?.IsOpen == true)
            {
                Channel.Close((int)HttpStatusCode.OK, "Channel closed");
            }

            if (ConsumingChannel?.IsOpen == true)
            {
                ConsumingChannel.Close((int)HttpStatusCode.OK, "Channel closed");
            }

            if (Connection?.IsOpen == true)
            {
                Connection.Close();
            }

            if (ConsumingConnection?.IsOpen == true)
            {
                ConsumingConnection.Close();
            }

            Channel?.Dispose();
            ConsumingChannel?.Dispose();
            Connection?.Dispose();
            ConsumingConnection?.Dispose();
        }

        private void ConfigureConnectionInfrastructure(RabbitMqSettings settings)
        {
            Connection = _rabbitMqConnectionFactory.CreateConnection(settings);
            ConsumingConnection = _rabbitMqConnectionFactory.CreateConnection(settings);

            if (Connection != null)
            {
                Connection.CallbackException += HandleConnectionCallbackException;

                if (Connection is IAutorecoveringConnection connection)
                {
                    connection.ConnectionRecoveryError += HandleConnectionRecoveryError;
                }

                Channel = Connection.CreateModel();
                Channel.CallbackException += HandleChannelCallbackException;
                Channel.BasicRecoverOk += HandleChannelBasicRecoverOk;
            }

            if (ConsumingConnection != null)
            {
                ConsumingConnection.CallbackException += HandleConnectionCallbackException;

                if (ConsumingConnection is IAutorecoveringConnection consumingConnection)
                {
                    consumingConnection.ConnectionRecoveryError += HandleConnectionRecoveryError;
                }

                ConsumingChannel = ConsumingConnection.CreateModel();
                ConsumingChannel.CallbackException += HandleChannelCallbackException;
                ConsumingChannel.BasicRecoverOk += HandleChannelBasicRecoverOk;
                _consumer = _rabbitMqConnectionFactory.CreateConsumer(ConsumingChannel);
            }
        }

        private void HandleConnectionCallbackException(object sender, CallbackExceptionEventArgs @event)
        {
            if (@event is null)
            {
                return;
            }

            throw @event.Exception;
        }

        private void HandleConnectionRecoveryError(object sender, ConnectionRecoveryErrorEventArgs @event)
        {
            if (@event is null)
            {
                return;
            }

            throw @event.Exception;
        }

        private void HandleChannelBasicRecoverOk(object sender, EventArgs @event)
        {
            if (@event is null)
            {
                return;
            }
        }

        private void HandleChannelCallbackException(object sender, CallbackExceptionEventArgs @event)
        {
            if (@event is null)
            {
                return;
            }

            throw @event.Exception;
        }

        private void SetExchange(IModel channel, GeneralExchange exchange)
        {
            channel.ExchangeDeclare(
                exchange: exchange.Name,
                type: exchange.Type,
                durable: exchange.Durable,
                autoDelete: exchange.AutoDelete,
                arguments: exchange.Arguments);

            if (exchange.Queues.Any())
            {
                foreach (GeneralQueue queue in exchange.Queues)
                {
                    BindQueue(channel, exchange.Name, queue);
                }
            }
        }

        private void SetQueue(IModel channel, GeneralQueue queue)
        {
            if (!string.IsNullOrEmpty(queue.Exchange))
            {
                BindQueue(channel, queue.Exchange, queue);
            }
            else
            {
                DeclareQueue(channel, queue);
            }
        }

        private void DeclareQueue(IModel channel, GeneralQueue queue)
        {
            channel.QueueDeclare(
                queue: queue.Name,
                durable: queue.Durable,
                exclusive: queue.Exclusive,
                autoDelete: queue.AutoDelete,
                arguments: queue.Arguments);
        }

        private void BindQueue(IModel channel, string exchange, GeneralQueue queue)
        {
            if (queue.RoutingKeys.Any())
            {
                foreach (string route in queue.RoutingKeys)
                {
                    DeclareQueue(channel, queue);
                    channel.QueueBind(queue: queue.Name, exchange: exchange, routingKey: route);
                }
            }
            else
            {
                DeclareQueue(channel, queue);
                channel.QueueBind(queue: queue.Name, exchange: exchange, routingKey: queue.Name);
            }
        }

        private IBasicProperties CreateProperties(string contentType = "")
        {
            IBasicProperties properties = Channel.CreateBasicProperties();
            properties.Persistent = true;

            if (!string.IsNullOrEmpty(contentType))
            {
                properties.ContentType = contentType;
            }

            return properties;
        }

        private byte[] ConvertBodyToBytes(string body)
        {
            return Encoding.UTF8.GetBytes(body);
        }

        private string ConvertBytesToBody(byte[] bytes)
        {
            return Encoding.UTF8.GetString(bytes);
        }

        private void PublishObjectToExchange<T>(IDistributedMessage<T> distributedMessage) where T : class
        {
            GeneralExchangeMessage<T> message = distributedMessage as GeneralExchangeMessage<T>;

            EnsureProducingChannelIsNotNull();
            ValidateExchange(message.Exchange);

            string json = Serializer.Serialize(message.Body);
            byte[] bytes = ConvertBodyToBytes(json);
            IBasicProperties properties = CreateProperties("application/json");

            SetExchange(Channel, message.Exchange);
            SendToExchange(bytes, properties, message.Exchange.Name, message.Exchange.RoutingKey);
        }

        private void PublishJsonToExchange(IDistributedMessage distributedMessage)
        {
            GeneralExchangeMessage message = distributedMessage as GeneralExchangeMessage;

            EnsureProducingChannelIsNotNull();
            ValidateExchange(message.Exchange);

            byte[] bytes = ConvertBodyToBytes(message.Body);
            IBasicProperties properties = CreateProperties("application/json");

            SetExchange(Channel, message.Exchange);
            SendToExchange(bytes, properties, message.Exchange.Name, message.Exchange.RoutingKey);
        }

        private void PublishStringToExchange(IDistributedMessage distributedMessage)
        {
            GeneralExchangeMessage message = distributedMessage as GeneralExchangeMessage;

            EnsureProducingChannelIsNotNull();
            ValidateExchange(message.Exchange);

            byte[] bytes = ConvertBodyToBytes(message.Body);
            IBasicProperties properties = CreateProperties();

            SetExchange(Channel, message.Exchange);
            SendToExchange(bytes, properties, message.Exchange.Name, message.Exchange.RoutingKey);
        }

        private void SendObjectToQueue<T>(IDistributedMessage<T> distributedMessage) where T : class
        {
            GeneralQueueMessage<T> message = distributedMessage as GeneralQueueMessage<T>;

            EnsureProducingChannelIsNotNull();
            ValidateQueue(message.Queue);

            string json = Serializer.Serialize(message.Body);
            byte[] bytes = ConvertBodyToBytes(json);
            IBasicProperties properties = CreateProperties("application/json");

            SetQueue(Channel, message.Queue);

            if (!string.IsNullOrEmpty(message.Queue.Exchange))
            {
                SendToQueue(bytes, properties, message.Queue.Name, message.Queue.Exchange);
            }
            else
            {
                SendToQueue(bytes, properties, message.Queue.Name);
            }
        }

        private void SendJsonToQueue(IDistributedMessage distributedMessage)
        {
            GeneralQueueMessage message = distributedMessage as GeneralQueueMessage;

            EnsureProducingChannelIsNotNull();
            ValidateQueue(message.Queue);

            byte[] bytes = ConvertBodyToBytes(message.Body);
            IBasicProperties properties = CreateProperties("application/json");

            SetQueue(Channel, message.Queue);

            if (!string.IsNullOrEmpty(message.Queue.Exchange))
            {
                SendToQueue(bytes, properties, message.Queue.Name, message.Queue.Exchange);
            }
            else
            {
                SendToQueue(bytes, properties, message.Queue.Name);
            }
        }

        private void SendStringToQueue(IDistributedMessage distributedMessage)
        {
            GeneralQueueMessage message = distributedMessage as GeneralQueueMessage;

            EnsureProducingChannelIsNotNull();
            ValidateQueue(message.Queue);

            byte[] bytes = ConvertBodyToBytes(message.Body);
            IBasicProperties properties = CreateProperties();

            SetQueue(Channel, message.Queue);

            if (!string.IsNullOrEmpty(message.Queue.Exchange))
            {
                SendToQueue(bytes, properties, message.Queue.Name, message.Queue.Exchange);
            }
            else
            {
                SendToQueue(bytes, properties, message.Queue.Name);
            }
        }

        private void SendToExchange(ReadOnlyMemory<byte> bytes, IBasicProperties properties, string exchange, string routingKey)
        {
            lock (_lock)
            {
                Channel.BasicPublish(exchange: exchange, routingKey: routingKey, basicProperties: properties, body: bytes);
            }
        }

        private void SendToQueue(ReadOnlyMemory<byte> bytes, IBasicProperties properties, string queue, string exchange = "")
        {
            lock (_lock)
            {
                Channel.BasicPublish(exchange: exchange, routingKey: queue, basicProperties: properties, body: bytes);
            }
        }

        private async Task ConsumerOnReceived(object sender, BasicDeliverEventArgs eventArgs)
        {
            string messageFromQueue = ConvertBytesToBody(eventArgs.Body.ToArray());

            await Task.Run(() =>
            {
                _action(messageFromQueue);
                ConsumingChannel.BasicAck(eventArgs.DeliveryTag, false);
            });
        }

        private void EnsureProducingChannelIsNotNull()
        {
            if (Channel is null)
            {
                throw new ProducingChannelIsNullException(-1, "Producing channel is null.");
            }
        }

        private void EnsureConsumingChannelIsNotNull()
        {
            if (ConsumingChannel is null)
            {
                throw new ConsumingChannelIsNullException(-1, "Consuming channel is null.");
            }
        }

        private void ValidateExchange(GeneralExchange exchange)
        {
            if (exchange is null)
            {
                throw new ExchangeIsNullException(-1, "Exchange is null.");
            }

            if (string.IsNullOrEmpty(exchange.Name))
            {
                throw new ExchangeIsNullException(-1, "Exchange name is null or empty.");
            }
        }

        private void ValidateQueue(GeneralQueue queue)
        {
            if (queue is null)
            {
                throw new QueueIsNullException(-1, "Queue is null.");
            }

            if (string.IsNullOrEmpty(queue.Name))
            {
                throw new QueueIsNullException(-1, "Queue name is null or empty.");
            }
        }

        private void ValidateConsumer(IConsumer consumer)
        {
            if (consumer is null)
            {
                throw new ConsumerIsNullException(-1, "Consumer is null.");
            }

            if (consumer.Queues.Count == 0)
            {
                throw new QueueIsNullException(-1, "Consumer queues are empty.");
            }

            if (consumer.Action is null)
            {
                throw new ConsumerActionIsNullException(-1, "Consumer action is null.");
            }
        }
    }
}
