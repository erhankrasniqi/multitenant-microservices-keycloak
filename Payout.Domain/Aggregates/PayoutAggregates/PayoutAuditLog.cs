using SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payout.Domain.Aggregates.PayoutAggregates
{
    public class PayoutAuditLog : AggregateRoot<int>
    {
        public int PayoutId { get; set; }
        public string Action { get; set; } = default!; // p.sh. "Created", "StatusChanged", "Failed"
        public string PerformedBy { get; set; } = default!; // user ose sistem
        public DateTime PerformedAt { get; set; } = DateTime.UtcNow;
        public string? Details { get; set; } // opsionale, për detaje shtesë
    }

}
