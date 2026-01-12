using System;

namespace TapyPay.Infrastructure.Contracts.DistributedMessageBroker.Exceptions
{
    public class ConsumerIsNullException : Exception
    {
        public readonly int ErrorCode;

        public ConsumerIsNullException()
            : base("Consumer is null.")
        {
            ErrorCode = -1;
        }

        public ConsumerIsNullException(string message)
            : base(message)
        {
            ErrorCode = -1;
        }

        public ConsumerIsNullException(int errorCode, string message)
            : base(message)
        {
            ErrorCode = errorCode;
        }

        public ConsumerIsNullException(int errorCode, string message, Exception innerException)
            : base(message, innerException)
        {
            ErrorCode = errorCode;
        }
    }
}
