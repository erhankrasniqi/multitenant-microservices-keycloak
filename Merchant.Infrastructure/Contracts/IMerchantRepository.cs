
using Merchant.Domain.Aggregate.MerchantAggregates;

namespace Merchant.Infrastructure.Contracts
{
    public interface IMerchantRepository : IRepository<Domain.Aggregate.MerchantAggregates.Merchant, int>
    {
        Task<IEnumerable<Domain.Aggregate.MerchantAggregates.Merchant>> GetMerchants(CancellationToken cancellationToken);
    }
}
