using System;

namespace TapyPay.Infrastructure.MessageBroker.Configuration
{
    public class RabbitMqSettings
    {
        public string Host { get; }
        public int Port { get; }
        public string Username { get; }
        public string Password { get; }
        public string ClientProvidedName { get; }
        public string VirtualHost { get; }
        public bool AutomaticRecoveryEnabled { get; }
        public bool TopologyRecoveryEnabled { get; }
        public TimeSpan RequestedConnectionTimeout { get; }
        public TimeSpan RequestedHeartbeat { get; }
        public bool DispatchConsumersAsync { get; }
        public int InitialConnectionRetries { get; }
        public int InitialConnectionRetryTimeoutMilliseconds { get; }

        public RabbitMqSettings(string host,
            int port,
            string username = "",
            string password = "",
            string clientProvidedName = "",
            string virualHost = "",
            bool automaticRecoveryEnabled = true,
            bool topologyRecoveryEnabled = true,
            double requestedConnectionTimeoutInSeconds = 60,
            double requestedHeartbeatInSeconds = 60,
            bool dispatchConsumersAsync = true,
            int initialConnectionRetries = 5,
            int initialConnectionRetryTimeoutMilliseconds = 200)
        {
            Host = host;
            Port = port;
            Username = username;
            Password = password;
            ClientProvidedName = clientProvidedName;
            VirtualHost = virualHost;
            AutomaticRecoveryEnabled = automaticRecoveryEnabled;
            TopologyRecoveryEnabled = topologyRecoveryEnabled;
            RequestedConnectionTimeout = TimeSpan.FromSeconds(requestedConnectionTimeoutInSeconds);
            RequestedHeartbeat = TimeSpan.FromSeconds(requestedHeartbeatInSeconds);
            DispatchConsumersAsync = dispatchConsumersAsync;
            InitialConnectionRetries = initialConnectionRetries;
            InitialConnectionRetryTimeoutMilliseconds = initialConnectionRetryTimeoutMilliseconds;
        }
    }
}
