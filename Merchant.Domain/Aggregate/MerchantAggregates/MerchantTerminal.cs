using SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merchant.Domain.Aggregate.MerchantAggregates
{
    public class MerchantTerminal : AggregateRoot<int>
    { 

        public int MerchantId { get; private set; }
        public string TerminalId { get; private set; } = default!;
        public string NFCDeviceId { get; private set; } = default!;
        public string Status { get; private set; } = default!;

        public Merchant Merchant { get; private set; } = default!;

        public static MerchantTerminal Create(
            int merchantId,
            Merchant merchant,
            string terminalId,
            string nfcDeviceId,
            string status)
        {
            var terminal = new MerchantTerminal
            {
                MerchantId = merchantId,
                Merchant = merchant,
                TerminalId = terminalId,
                NFCDeviceId = nfcDeviceId,
                Status = status
            };

            terminal.Validate();

            return terminal;
        }

        private void Validate()
        {
            if (MerchantId <= 0)
                ThrowDomainException("MerchantId must be greater than zero.");

            if (Merchant == null)
                ThrowDomainException("Merchant reference is required.");

            if (string.IsNullOrWhiteSpace(TerminalId))
                ThrowDomainException("TerminalId is required.");

            if (string.IsNullOrWhiteSpace(NFCDeviceId))
                ThrowDomainException("NFCDeviceId is required.");

            if (string.IsNullOrWhiteSpace(Status))
                ThrowDomainException("Status is required.");
        }

        private void ThrowDomainException(string message)
        {
            throw new InvalidOperationException(message);
        }
    }

}
