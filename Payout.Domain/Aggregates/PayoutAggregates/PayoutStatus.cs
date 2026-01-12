using SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payout.Domain.Aggregates.PayoutAggregates
{
    public class PayoutStatus : AggregateRoot<int>
    {
        public string Name { get; set; } = default!; // p.sh. Pending, Processing, Completed, Failed
        public ICollection<Payout> Payouts { get; set; } = new List<Payout>();
    }

}
