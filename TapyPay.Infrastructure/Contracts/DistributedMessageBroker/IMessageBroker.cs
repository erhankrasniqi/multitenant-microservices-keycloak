using System.Threading;
using System.Threading.Tasks;

namespace TapyPay.Infrastructure.Contracts.DistributedMessageBroker
{
    public interface IMessageBroker
    {
        Task PublishObject<T>(IDistributedMessage<T> distributedMessage, CancellationToken cancellationToken = default) where T : class;
        Task PublishJson(IDistributedMessage distributedMessage, CancellationToken cancellationToken = default);
        Task PublishString(IDistributedMessage distributedMessage, CancellationToken cancellationToken = default);
        Task SendObject<T>(IDistributedMessage<T> distributedMessage, CancellationToken cancellationToken = default) where T : class;
        Task SendJson(IDistributedMessage distributedMessage, CancellationToken cancellationToken = default);
        Task SendString(IDistributedMessage distributedMessage, CancellationToken cancellationToken = default);
        Task StartConsuming(IConsumer consumer);
        Task StopConsuming();
        void Disconnect();
    }
}
