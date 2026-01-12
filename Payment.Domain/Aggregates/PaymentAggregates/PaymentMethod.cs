

using SharedKernel;

namespace Payment.Domain.Aggregates.PaymentAggregates
{
    public class PaymentMethod : AggregateRoot<int>
    {
        public string Name { get; set; } = default!; // e.g., Card, NFC, QR
        public int ProviderId { get; set; }
        public Provider Provider { get; set; } = default!;
        public ICollection<Payments> Payments { get; set; } = new List<Payments>();
    }
}
