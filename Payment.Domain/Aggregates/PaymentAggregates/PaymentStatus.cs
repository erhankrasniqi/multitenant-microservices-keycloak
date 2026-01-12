

using SharedKernel;

namespace Payment.Domain.Aggregates.PaymentAggregates
{
    public class PaymentStatus : AggregateRoot<int>
    {
        public string Name { get; set; } = default!;   
        public ICollection<PaymentStatusHistory> PaymentStatusHistories { get; set; } = new List<PaymentStatusHistory>();
    }
}
