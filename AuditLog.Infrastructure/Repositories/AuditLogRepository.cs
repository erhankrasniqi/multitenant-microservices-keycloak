 
using AuditLog.Infrastructure.Contracts; 
using Microsoft.EntityFrameworkCore; 
using AuditLog.Infrastructure.Database;

namespace AuditLog.Infrastructure.Repositories
{
    public class AuditLogRepository : GenericRepository<Domain.Aggregates.AuditLogAggregates.AuditLog, int>, IAuditLogRepository
    {
        private readonly TapyPayAuditLogDbContext _dbContext;

        public AuditLogRepository(TapyPayAuditLogDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Domain.Aggregates.AuditLogAggregates.AuditLog>> GetMerchants(CancellationToken cancellationToken)
        {
            return await _dbContext.AnalyticsEventRecords 
            .ToListAsync(cancellationToken);
        }
    }
}