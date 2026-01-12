using SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Domain.Aggregates.PaymentAggregates
{
    public class Payments : AggregateRoot<int>
    {
        public int MerchantId { get; set; }
        public int UserId { get; set; }

        public decimal Amount { get; set; }

        public int CurrencyId { get; set; }
        public Currency Currency { get; set; }

        public int PaymentMethodId { get; set; }
        public PaymentMethod PaymentMethod { get; set; } 

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? ProcessedAt { get; set; }

        public ICollection<PaymentStatusHistory> PaymentStatusHistories { get; set; } = new List<PaymentStatusHistory>();
    }
}
