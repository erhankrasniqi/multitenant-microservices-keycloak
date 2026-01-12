
  

namespace Payout.Infrastructure.Contracts 
{
    public interface IPayoutRepository : IRepository<Domain.Aggregates.PayoutAggregates.Payout, int>
    {
        Task<IEnumerable<Domain.Aggregates.PayoutAggregates.Payout>> GetPayouts(CancellationToken cancellationToken);
    }
}
