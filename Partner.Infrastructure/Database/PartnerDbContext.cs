using Microsoft.EntityFrameworkCore; 
using Partner.Domain.Aggregates.PartnerAggregates;

namespace Partner.Infrastructure.Database
{
    public class PartnerDbContext : DbContext
    {
        public DbSet<Partner.Domain.Aggregates.PartnerAggregates.Partner> Partners { get; set; } 
        public DbSet<Role> Roles { get; set; } 
        public DbSet<PartnerAddress> PartnerAddress { get; set; } 
        public DbSet<ContactInfo> ContactInfos { get; set; } 
        public DbSet<PartnerMerchant> PartnerMerchants { get; set; } 
        public DbSet<PartnerPaymentPreference> PartnerPaymentPreferences { get; set; } 
        public DbSet<PartnerUser> PartnerUsers { get; set; }  

        public PartnerDbContext(DbContextOptions<PartnerDbContext> options)
            : base(options)
        {
            //
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ContactInfo>()
                 .HasIndex(p => new { p.Id })
                 .HasDatabaseName("IX_ContactInfo_Id");

            modelBuilder.Entity<Domain.Aggregates.PartnerAggregates.Partner>()
               .HasIndex(p => new { p.Id })
               .HasDatabaseName("IX_Partner_Id_TenantId");

            modelBuilder.Entity<PartnerAddress>()
            .HasIndex(p => new { p.Id })
            .HasDatabaseName("IX_PartnerAddress_Id");

            modelBuilder.Entity<PartnerMerchant>()
            .HasIndex(p => new { p.Id,p.PartnerId, p.MerchantId })
            .HasDatabaseName("IX_PartnerMerchant_Id_PartnerId_MerchantId");

            modelBuilder.Entity<PartnerPaymentPreference>()
            .HasIndex(p => new { p.Id })
            .HasDatabaseName("IX_PartnerPaymentPreference_Id");

            modelBuilder.Entity<PartnerUser>()
            .HasIndex(p => new { p.Id , p.PartnerId})
            .HasDatabaseName("IX_PartnerUser_Id_PartnerId");
             



        }

    }
}
