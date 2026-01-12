using Merchant.Infrastructure.Contracts;
using Merchant.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using SharedKernel; 

namespace Merchant.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TapyPayMerchantDbContext _dbContext;

        public UnitOfWork(TapyPayMerchantDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Save(CancellationToken cancellationToken = default)
        {
            SetDefaultProperties(_dbContext);
            return await _dbContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        private void SetDefaultProperties(TapyPayMerchantDbContext dbContext)
        {
            var modifiedItems = dbContext.ChangeTracker
                .Entries<IEntity<int>>()
                .Where(entity => entity.State == EntityState.Modified);

            var newItems = dbContext.ChangeTracker
                .Entries<IEntity<int>>()
                .Where(entity => entity.State == EntityState.Added);

            foreach (var item in modifiedItems)
            {
                item.Entity.SetModifiedOn(DateTime.UtcNow);
            }

            foreach (var item in newItems)
            {
                item.Entity.SetCreatedOn(DateTime.UtcNow);
            }
        }
    }
}
