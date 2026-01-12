namespace TapyPay.Infrastructure.Contracts.DistributedMessageBroker.Models
{
    public abstract class ExchangeMessage
    {
        public GeneralExchange Exchange { get; set; }
    }
}
