

namespace AuditLog.Infrastructure.Contracts
{
    public interface IUnitOfWork
    {
        Task<int> Save(CancellationToken cancellationToken = default);
    }
}
