using System;

namespace TapyPay.Infrastructure.Contracts.DistributedMessageBroker.Exceptions
{
    public class ExchangeIsNullException : Exception
    {
        public readonly int ErrorCode;

        public ExchangeIsNullException()
            : base("Exchange is null.")
        {
            ErrorCode = -1;
        }

        public ExchangeIsNullException(string message)
            : base(message)
        {
            ErrorCode = -1;
        }

        public ExchangeIsNullException(int errorCode, string message)
            : base(message)
        {
            ErrorCode = errorCode;
        }

        public ExchangeIsNullException(int errorCode, string message, Exception innerException)
            : base(message, innerException)
        {
            ErrorCode = errorCode;
        }
    }
}
