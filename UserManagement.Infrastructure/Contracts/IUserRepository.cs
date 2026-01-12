 
using UserManagement.Domain.Aggregates.UsersAggregates;

namespace UserManagement.Infrastructure.Contracts
{
    public interface IUserRepository : IRepository<Users, int>
    {
        Task<IEnumerable<Users>> GetUserwithAddress(CancellationToken cancellationToken);
    }
}
