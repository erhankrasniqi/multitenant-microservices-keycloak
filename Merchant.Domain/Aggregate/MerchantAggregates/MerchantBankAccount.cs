using SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merchant.Domain.Aggregate.MerchantAggregates
{
    public class MerchantBankAccount : AggregateRoot<int>
    {
        private MerchantBankAccount() { }

        public int MerchantId { get; private set; }

        public string IBAN { get; private set; } = default!;
        public string BankName { get; private set; } = default!;
        public bool Verified { get; private set; }

        public Merchant Merchant { get; private set; } = default!;

        public static MerchantBankAccount Create(
            int merchantId,
            Merchant merchant,
            string iban,
            string bankName,
            bool verified = false)
        {
            var bankAccount = new MerchantBankAccount
            {
                MerchantId = merchantId,
                Merchant = merchant,
                IBAN = iban,
                BankName = bankName,
                Verified = verified
            };

            bankAccount.BankAccountValidate();

            return bankAccount;
        }

        private void BankAccountValidate()
        {
            if (MerchantId <= 0)
                ThrowDomainException("MerchantId must be greater than zero.");

            if (Merchant == null)
                ThrowDomainException("Merchant reference is required.");

            if (string.IsNullOrWhiteSpace(IBAN))
                ThrowDomainException("IBAN is required.");

            if (string.IsNullOrWhiteSpace(BankName))
                ThrowDomainException("Bank name is required.");
        }

        private void ThrowDomainException(string message)
        {
            throw new InvalidOperationException(message);
        }
         
    }

}
