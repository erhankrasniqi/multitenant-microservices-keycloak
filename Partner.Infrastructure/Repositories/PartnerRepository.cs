
using Microsoft.EntityFrameworkCore;
using Partner.Domain.Aggregates.PartnerAggregates;
using Partner.Infrastructure.Contracts;
using Partner.Infrastructure.Database;
using Partner.Infrastructure.Repositories;

namespace Partner.Infrastructure.Repositories
{
    public class PartnerRepository : GenericRepository<Domain.Aggregates.PartnerAggregates.Partner, int>, IPartnerRepository
    {
        private readonly PartnerDbContext _dbContext;

        public PartnerRepository(PartnerDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Partner.Domain.Aggregates.PartnerAggregates.Partner>> GetPartners(CancellationToken cancellationToken)
        {
            return await _dbContext.Partners 
            .ToListAsync(cancellationToken);
        }
    }
}