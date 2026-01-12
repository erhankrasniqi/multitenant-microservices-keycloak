using SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analytics.Domain.Aggregates.AnalyticsAggregates
{ 
    public class PaymentAnalytics : AggregateRoot<int>
    {
        public string TenantId { get; set; }
        public DateTime Date { get; set; }   
        public int TotalPaymentsCount { get; set; }
        public decimal TotalPaymentsAmount { get; set; }
        public int SuccessfulPaymentsCount { get; set; }
        public int FailedPaymentsCount { get; set; }
        public ICollection<PaymentMethodAnalytics> PaymentMethodStats { get; set; } = new List<PaymentMethodAnalytics>();
    }
}
