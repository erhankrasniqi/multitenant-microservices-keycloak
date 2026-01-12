 

namespace AuditLog.Infrastructure.Contracts
{
    public interface IAuditLogRepository : IRepository<Domain.Aggregates.AuditLogAggregates.AuditLog, int>
    {
        Task<IEnumerable<Domain.Aggregates.AuditLogAggregates.AuditLog>> GetMerchants(CancellationToken cancellationToken);
    }
}
