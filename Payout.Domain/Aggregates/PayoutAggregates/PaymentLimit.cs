using SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payout.Domain.Aggregates.PayoutAggregates
{
    public class PaymentLimit : AggregateRoot<int>
    {
        public int PayoutPaymentMethodId { get; set; }
        public PayoutPaymentMethod PayoutPaymentMethod { get; set; } = default!;

        public decimal MaxTransactionAmount { get; set; }
        public decimal DailyLimitAmount { get; set; }
        public int MaxTransactionsPerDay { get; set; }

        public DateTime EffectiveFrom { get; set; }
        public DateTime? EffectiveTo { get; set; }
    }
}
