using System;

namespace TapyPay.Infrastructure.Contracts.DistributedMessageBroker.Exceptions
{
    public class ConsumingChannelIsNullException : Exception
    {
        public readonly int ErrorCode;

        public ConsumingChannelIsNullException()
            : base("Consuming channel is null.")
        {
            ErrorCode = -1;
        }

        public ConsumingChannelIsNullException(string message)
            : base(message)
        {
            ErrorCode = -1;
        }

        public ConsumingChannelIsNullException(int errorCode, string message)
            : base(message)
        {
            ErrorCode = errorCode;
        }

        public ConsumingChannelIsNullException(int errorCode, string message, Exception innerException)
            : base(message, innerException)
        {
            ErrorCode = errorCode;
        }
    }
}
