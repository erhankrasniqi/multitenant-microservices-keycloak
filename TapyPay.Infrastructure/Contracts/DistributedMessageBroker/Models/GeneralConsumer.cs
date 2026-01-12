using System;
using System.Collections.Generic;

namespace TapyPay.Infrastructure.Contracts.DistributedMessageBroker.Models
{
    public class GeneralConsumer : IConsumer
    {
        public IList<string> Queues { get; set; } = new List<string>();
        public Action<string> Action { get; set; }
    }
}
