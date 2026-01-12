using SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payout.Domain.Aggregates.PayoutAggregates
{
    public class PayoutRetryLog : AggregateRoot<int>
    {
        public int PayoutId { get; set; }
        public int AttemptNumber { get; set; }
        public DateTime AttemptedAt { get; set; } = DateTime.UtcNow;
        public string? FailureReason { get; set; }
    }

}
