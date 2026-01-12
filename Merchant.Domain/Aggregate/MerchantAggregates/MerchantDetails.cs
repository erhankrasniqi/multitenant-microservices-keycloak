using SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merchant.Domain.Aggregate.MerchantAggregates
{
    public class MerchantDetails : AggregateRoot<int>
    {
        private MerchantDetails() { }

        public int MerchantId { get; private set; }

        public string BusinessRegistrationNumber { get; private set; } = default!;
        public string Website { get; private set; } = default!;
        public string Description { get; private set; } = default!;

        public Merchant Merchant { get; private set; } = default!;

        public static MerchantDetails Create(
            int merchantId,
            Merchant merchant,
            string businessRegistrationNumber,
            string website,
            string description)
        {
            var details = new MerchantDetails
            {
                MerchantId = merchantId,
                Merchant = merchant,
                BusinessRegistrationNumber = businessRegistrationNumber,
                Website = website,
                Description = description
            };

            details.MerchantDetailsValidate();

            return details;
        }

        private void MerchantDetailsValidate()
        {
            if (MerchantId <= 0)
                ThrowDomainException("MerchantId must be greater than zero.");

            if (Merchant == null)
                ThrowDomainException("Merchant reference is required.");

            if (string.IsNullOrWhiteSpace(BusinessRegistrationNumber))
                ThrowDomainException("Business registration number is required.");

            if (string.IsNullOrWhiteSpace(Website))
                ThrowDomainException("Website is required.");

            if (string.IsNullOrWhiteSpace(Description))
                ThrowDomainException("Description is required.");
        }

        private void ThrowDomainException(string message)
        {
            throw new InvalidOperationException(message);
        }
    }

}
