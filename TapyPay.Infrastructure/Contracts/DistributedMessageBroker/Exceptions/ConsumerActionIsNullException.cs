using System;

namespace TapyPay.Infrastructure.Contracts.DistributedMessageBroker.Exceptions
{
    public class ConsumerActionIsNullException : Exception
    {
        public readonly int ErrorCode;

        public ConsumerActionIsNullException()
            : base("Consumer action is null.")
        {
            ErrorCode = -1;
        }

        public ConsumerActionIsNullException(string message)
            : base(message)
        {
            ErrorCode = -1;
        }

        public ConsumerActionIsNullException(int errorCode, string message)
            : base(message)
        {
            ErrorCode = errorCode;
        }

        public ConsumerActionIsNullException(int errorCode, string message, Exception innerException)
            : base(message, innerException)
        {
            ErrorCode = errorCode;
        }
    }
}
