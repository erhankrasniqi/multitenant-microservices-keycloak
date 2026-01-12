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
        }
    }
}
