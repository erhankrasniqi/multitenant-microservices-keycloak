
using Analytics.Domain.Aggregates.AnalyticsAggregates;

namespace Analytics.Infrastructure.Contracts
{
    public interface IAnalyticsRepository : IRepository<AnalyticsEventRecord, int>
    {
        Task<IEnumerable<AnalyticsEventRecord>> GetMerchants(CancellationToken cancellationToken);
    }
}
