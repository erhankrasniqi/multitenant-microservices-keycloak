using SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Domain.Aggregates.PaymentAggregates
{
    public class PaymentStatusHistory : AggregateRoot<int>
    {
        public int PaymentId { get; set; }
        public Payments Payment { get; set; } = default!; // lidhja me pagesën

        public int StatusId { get; set; }
        public PaymentStatus PaymentStatus { get; set; } = default!;

        public DateTime ChangedAt { get; set; } = DateTime.UtcNow; // gjithmonë kur ndryshon statusi
    }

}
