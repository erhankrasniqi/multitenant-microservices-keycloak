 
namespace Partner.Infrastructure.Contracts
{
    public interface IUnitOfWork
    {
        Task<int> Save(CancellationToken cancellationToken = default);
    }
}
