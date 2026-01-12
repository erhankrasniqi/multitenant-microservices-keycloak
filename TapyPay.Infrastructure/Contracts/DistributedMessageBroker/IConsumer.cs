using System;
using System.Collections.Generic;

namespace TapyPay.Infrastructure.Contracts.DistributedMessageBroker
{
    public interface IConsumer
    {
        IList<string> Queues { get; set; }
        Action<string> Action { get; set; }
    }
}
