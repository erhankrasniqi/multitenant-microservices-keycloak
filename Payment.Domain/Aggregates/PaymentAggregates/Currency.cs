using SharedKernel; 

namespace Payment.Domain.Aggregates.PaymentAggregates
{
    public class Currency :AggregateRoot<int>       
    {
        public string Code { get; set; } = default!; // e.g., EUR, USD
        public string Symbol { get; set; } = default!; // e.g., €, $
        public string Name { get; set; } = default!;   // Euro, Dollar

        public ICollection<Payments> Payments { get; set; } = new List<Payments>();
    }

}
