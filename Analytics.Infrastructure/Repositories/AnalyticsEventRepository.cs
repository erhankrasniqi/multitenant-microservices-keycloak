using Analytics.Domain.Aggregates.AnalyticsAggregates;
using Analytics.Infrastructure.Contracts;
using Analytics.Infrastructure.Database; 
using Microsoft.EntityFrameworkCore; 

namespace Analytics.Infrastructure.Repositories
{
    public class AnalyticsEventRepository : GenericRepository<AnalyticsEventRecord, int>, IAnalyticsRepository
    {
        private readonly TapyPayAnalyticsDbContext _dbContext;

        public AnalyticsEventRepository(TapyPayAnalyticsDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<AnalyticsEventRecord>> GetMerchants(CancellationToken cancellationToken)
        {
            return await _dbContext.AnalyticsEventRecords 
            .ToListAsync(cancellationToken);
        }
    }
}