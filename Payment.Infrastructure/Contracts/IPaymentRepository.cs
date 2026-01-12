

using Payment.Domain.Aggregates.PaymentAggregates;

namespace Payment.Infrastructure.Contracts 
{
    public interface IPaymentRepository : IRepository<Payments, int>
    {
        Task<IEnumerable<Payments>> GetPartners(CancellationToken cancellationToken);
    }
}
