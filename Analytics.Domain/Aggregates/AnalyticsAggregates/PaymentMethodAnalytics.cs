using SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analytics.Domain.Aggregates.AnalyticsAggregates
{
    public class PaymentMethodAnalytics : AggregateRoot<int>
    {
        public int PaymentAnalyticsId { get; set; }
        public PaymentAnalytics PaymentAnalytics { get; set; } = default!;

        public int PaymentMethodId { get; set; }
        public string PaymentMethodName { get; set; } = default!;

        public int Count { get; set; }
        public decimal Amount { get; set; }
    }
}
