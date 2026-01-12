using System.Collections.Generic;

namespace TapyPay.Infrastructure.Contracts.DistributedMessageBroker.Models
{
    public class GeneralQueue
    {
        public string Name { get; set; }
        public string Exchange { get; set; }
        public bool Durable { get; set; }
        public bool Exclusive { get; set; }
        public bool AutoDelete { get; set; }
        public HashSet<string> RoutingKeys { get; set; } = new HashSet<string>();
        public IDictionary<string, object> Arguments { get; set; } = new Dictionary<string, object>();
    }
}
