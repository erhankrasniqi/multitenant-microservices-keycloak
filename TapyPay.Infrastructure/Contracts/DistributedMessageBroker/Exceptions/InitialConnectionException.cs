using System;

namespace TapyPay.Infrastructure.Contracts.DistributedMessageBroker.Exceptions
{
    public class InitialConnectionException : Exception
    {
        public readonly int ErrorCode;

        public InitialConnectionException()
            : base("Could not establish an initial connection.")
        {
            ErrorCode = -1;
        }

        public InitialConnectionException(string message)
            : base(message)
        {
            ErrorCode = -1;
        }

        public InitialConnectionException(int errorCode, string message)
            : base(message)
        {
            ErrorCode = errorCode;
        }

        public InitialConnectionException(int errorCode, string message, Exception innerException)
            : base(message, innerException)
        {
            ErrorCode = errorCode;
        }
    }
}
