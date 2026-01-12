namespace TapyPay.Infrastructure.Contracts.DistributedMessageBroker
{
    public interface IDistributedMessage
    {
        string Body { get; set; }
    }

    public interface IDistributedMessage<T> where T : class
    {
        T Body { get; set; }
    }
}
