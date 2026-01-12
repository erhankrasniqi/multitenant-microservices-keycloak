using SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analytics.Domain.Aggregates.AnalyticsAggregates
{
    // Statistika për pagesat e lëshuara (Payouts)
    public class PayoutAnalytics : AggregateRoot<int>
    {
        public string TenantId { get; set; }
        public DateTime Date { get; set; }
        public int TotalPayoutsCount { get; set; }
        public decimal TotalPayoutsAmount { get; set; }
        public int SuccessfulPayoutsCount { get; set; }
        public int FailedPayoutsCount { get; set; }
    }
}
