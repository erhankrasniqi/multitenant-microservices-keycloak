
using Microsoft.EntityFrameworkCore;
using Payout.Infrastructure.Contracts;
using Payout.Infrastructure.Database;
using Payout.Infrastructure.Repositories;

namespace Payment.Infrastructure.Repositories
{
    public class PayoutRepository : GenericRepository<Payout.Domain.Aggregates.PayoutAggregates.Payout, int>, IPayoutRepository
    {
        private readonly PayoutDbContext _dbContext;

        public PayoutRepository(PayoutDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Payout.Domain.Aggregates.PayoutAggregates.Payout>> GetPayouts(CancellationToken cancellationToken)
        {
            return await _dbContext.Payout
            .ToListAsync(cancellationToken);
        }
    }
}