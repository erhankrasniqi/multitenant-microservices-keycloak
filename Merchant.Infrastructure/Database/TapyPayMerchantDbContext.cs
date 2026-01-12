using Merchant.Domain.Aggregate.MerchantAggregates;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merchant.Infrastructure.Database
{
    public class TapyPayMerchantDbContext : DbContext
    {
        public DbSet<Domain.Aggregate.MerchantAggregates.Merchant> Merchants { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<MerchantBankAccount> MerchantBankAccounts { get; set; }
        public DbSet<MerchantDetails> MerchantDetails { get; set; }
        public DbSet<MerchantStatus> MerchantStatus { get; set; }
        public DbSet<MerchantTerminal> MerchantTerminal { get; set; }

        public TapyPayMerchantDbContext(DbContextOptions<TapyPayMerchantDbContext> options)
            : base(options)
        {
            //
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
