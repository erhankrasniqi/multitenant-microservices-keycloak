using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Messaging.Configuration
{
    public class RabbitMqOptions
    {
        public string HostName { get; set; } = "localhost";
        public string UserName { get; set; } = "guest";
        public string Password { get; set; } = "guest";
        public string ExchangeName { get; set; } = "default_exchange";
    }
}
