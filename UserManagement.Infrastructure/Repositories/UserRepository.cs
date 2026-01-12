
using Microsoft.EntityFrameworkCore;
using UserManagement.Domain.Aggregates.UsersAggregates;
using UserManagement.Infrastructure.Contracts;
using UserManagement.Infrastructure.Database;

namespace UserManagement.Infrastructure.Repositories
{
    public class UserRepository : GenericRepository<Users, int>, IUserRepository
    {
        private readonly TapyPayDbContext _dbContext;

        public UserRepository(TapyPayDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Users>> GetUserwithAddress(CancellationToken cancellationToken)
        {
            return await _dbContext.Users
            .Include(u => u.Addresses)   
            .ToListAsync(cancellationToken);
        }
    }
}