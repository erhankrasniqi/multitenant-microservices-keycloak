using SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Domain.Aggregates.PaymentAggregates
{
    public class PaymentLimit : AggregateRoot<int>
    {
        public int PaymentMethodId { get; set; }
        public PaymentMethod PaymentMethod { get; set; } = default!;
        public string TenantId { get; set; }
        public decimal MaxTransactionAmount { get; set; }
        public decimal DailyLimitAmount { get; set; }
        public int MaxTransactionsPerDay { get; set; }

        public DateTime EffectiveFrom { get; set; }
        public DateTime? EffectiveTo { get; set; }
    }

}
