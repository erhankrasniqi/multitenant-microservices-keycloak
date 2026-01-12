using System;

namespace TapyPay.Infrastructure.Contracts.DistributedMessageBroker.Exceptions
{
    public class ProducingChannelIsNullException : Exception
    {
        public readonly int ErrorCode;

        public ProducingChannelIsNullException()
            : base("Producing channel is null.")
        {
            ErrorCode = -1;
        }

        public ProducingChannelIsNullException(string message)
            : base(message)
        {
            ErrorCode = -1;
        }

        public ProducingChannelIsNullException(int errorCode, string message)
            : base(message)
        {
            ErrorCode = errorCode;
        }

        public ProducingChannelIsNullException(int errorCode, string message, Exception innerException)
            : base(message, innerException)
        {
            ErrorCode = errorCode;
        }
    }
}
