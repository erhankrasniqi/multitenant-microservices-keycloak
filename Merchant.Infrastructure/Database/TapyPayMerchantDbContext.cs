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

            modelBuilder.Entity<Address>()
                .HasIndex(p => new { p.Id })
                .HasDatabaseName("IX_Address_Id");

            modelBuilder.Entity<Domain.Aggregate.MerchantAggregates.Merchant>()
               .HasIndex(p => new { p.Id, p.TenantId })
               .HasDatabaseName("IX_Merchant_Id_TenantId");

            modelBuilder.Entity<MerchantBankAccount>()
             .HasIndex(p => new { p.Id, p.MerchantId, p.BankName })
             .HasDatabaseName("IX_MerchantBankAccount_Id_MerchantId_BankName");

            modelBuilder.Entity<MerchantDetails>()
               .HasIndex(p => new { p.Id, p.MerchantId })
               .HasDatabaseName("IX_MerchantDetails_Id_MerchantId");

            modelBuilder.Entity<MerchantStatus>()
              .HasIndex(p => new { p.Id })
              .HasDatabaseName("IX_MerchantStatus_Id");

            modelBuilder.Entity<MerchantTerminal>()
              .HasIndex(p => new { p.Id, p.MerchantId})
              .HasDatabaseName("IX_MerchantTerminal_Id_MerchantId");
        }

    }
}
