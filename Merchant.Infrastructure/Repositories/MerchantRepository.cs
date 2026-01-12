using Merchant.Infrastructure.Contracts;
using Merchant.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merchant.Infrastructure.Repositories
{
    public class MerchantRepository : GenericRepository<Domain.Aggregate.MerchantAggregates.Merchant, int>, IMerchantRepository
    {
        private readonly TapyPayMerchantDbContext _dbContext;

        public MerchantRepository(TapyPayMerchantDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Domain.Aggregate.MerchantAggregates.Merchant>> GetMerchants(CancellationToken cancellationToken)
        {
            return await _dbContext.Merchants 
            .ToListAsync(cancellationToken);
        }
    }
}