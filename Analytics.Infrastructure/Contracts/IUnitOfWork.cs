 

namespace Analytics.Infrastructure.Contracts
{
    public interface IUnitOfWork
    {
        Task<int> Save(CancellationToken cancellationToken = default);
    }
}
