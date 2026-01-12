using System;

namespace TapyPay.Infrastructure.Contracts.DistributedMessageBroker.Exceptions
{
    public class ConsumerMessageException : Exception
    {
        public readonly int ErrorCode;

        public ConsumerMessageException()
            : base("An error occurred when consuming messages from the message broker.")
        {
            ErrorCode = -1;
        }

        public ConsumerMessageException(string message)
            : base(message)
        {
            ErrorCode = -1;
        }

        public ConsumerMessageException(int errorCode, string message)
            : base(message)
        {
            ErrorCode = errorCode;
        }

        public ConsumerMessageException(int errorCode, string message, Exception innerException)
            : base(message, innerException)
        {
            ErrorCode = errorCode;
        }
    }
}
