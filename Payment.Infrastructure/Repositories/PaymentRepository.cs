
using Microsoft.EntityFrameworkCore;
using Payment.Domain.Aggregates.PaymentAggregates;
using Payment.Infrastructure.Contracts;
using Payment.Infrastructure.Database; 

namespace Payment.Infrastructure.Repositories
{
    public class PaymentRepository : GenericRepository<Payments, int>, IPaymentRepository
    {
        private readonly PaymentDbContext _dbContext;

        public PaymentRepository(PaymentDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Payments>> GetPartners(CancellationToken cancellationToken)
        {
            return await _dbContext.Payments
            .ToListAsync(cancellationToken);
        }
    }
}