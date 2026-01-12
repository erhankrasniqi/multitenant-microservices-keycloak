using SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payout.Domain.Aggregates.PayoutAggregates
{
    public class PayoutHistory : AggregateRoot<int>
    {
        public int PayoutId { get; set; }
        public Payout Payout { get; set; } = default!;

        public int StatusId { get; set; }
        public PayoutStatus Status { get; set; } = default!;

        public DateTime ChangedAt { get; set; } = DateTime.UtcNow;
    }

}
