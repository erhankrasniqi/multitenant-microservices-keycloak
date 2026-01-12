using SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Partner.Domain.Aggregates.PartnerAggregates
{
    public class PartnerMerchant : AggregateRoot<int>
    {
        public int PartnerId { get; set; }
        public int MerchantId { get; set; } // nga MerchantService

        public DateTime OnboardedAt { get; set; }
    }

}
