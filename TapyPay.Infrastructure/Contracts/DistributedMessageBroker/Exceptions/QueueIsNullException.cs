using System;

namespace TapyPay.Infrastructure.Contracts.DistributedMessageBroker.Exceptions
{
    public class QueueIsNullException : Exception
    {
        public readonly int ErrorCode;

        public QueueIsNullException()
            : base("Queue is null.")
        {
            ErrorCode = -1;
        }

        public QueueIsNullException(string message)
            : base(message)
        {
            ErrorCode = -1;
        }

        public QueueIsNullException(int errorCode, string message)
            : base(message)
        {
            ErrorCode = errorCode;
        }

        public QueueIsNullException(int errorCode, string message, Exception innerException)
            : base(message, innerException)
        {
            ErrorCode = errorCode;
        }
    }
}
