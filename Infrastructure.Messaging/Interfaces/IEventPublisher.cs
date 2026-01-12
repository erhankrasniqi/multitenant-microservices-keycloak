using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Messaging.Interfaces
{
    public interface IEventPublisher
    {
        Task PublishAsync<T>(T @event, string routingKey);
    }
}
