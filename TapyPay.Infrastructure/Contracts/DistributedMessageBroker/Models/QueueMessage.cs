namespace TapyPay.Infrastructure.Contracts.DistributedMessageBroker.Models
{
    public abstract class QueueMessage
    {
        public GeneralQueue Queue { get; set; }
    }
}
