using SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payout.Domain.Aggregates.PayoutAggregates
{
    public class Commission : AggregateRoot<int>
    {
        public int PartnerId { get; set; }
        public string TenantId { get; set; }
        public decimal Percentage { get; set; } // 5 përqind = 5.0
        public decimal FixedAmount { get; set; } // Opsionale, nëse ke komision fiks

        public DateTime EffectiveFrom { get; set; }
        public DateTime? EffectiveTo { get; set; }
    }

}
