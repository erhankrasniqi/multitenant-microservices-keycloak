using SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merchant.Domain.Aggregate.MerchantAggregates
{
    public class MerchantStatus : AggregateRoot<int>
    {
        private MerchantStatus() { }

        public string Name { get; private set; } = default!;
        public ICollection<Merchant> Merchants { get; private set; } = new List<Merchant>();

        public static MerchantStatus Create(string name)
        {
            var status = new MerchantStatus
            {
                Name = name
            };

            status.Validate();

            return status;
        }

        private void Validate()
        {
            if (string.IsNullOrWhiteSpace(Name))
                ThrowDomainException("Status name is required.");
        }

        private void ThrowDomainException(string message)
        {
            throw new InvalidOperationException(message);
        }
    }

}
