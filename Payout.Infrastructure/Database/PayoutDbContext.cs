using Microsoft.EntityFrameworkCore;
using Payout.Domain.Aggregates.PayoutAggregates;

namespace Payout.Infrastructure.Database
{
    public class PayoutDbContext : DbContext
    {   
        public DbSet<Payout.Domain.Aggregates.PayoutAggregates.Payout> Payout { get; set; }
        public DbSet<Commission> Commission { get; set; }
        public DbSet<PaymentLimit> PaymentLimit { get; set; }
        public DbSet<PayoutAuditLog> PayoutAuditLog { get; set; }
        public DbSet<PayoutCurrency> PayoutCurrency { get; set; }
        public DbSet<PayoutHistory> PayoutHistory { get; set; }
        public DbSet<PayoutPaymentMethod> PayoutPaymentMethod { get; set; } 
        public DbSet<PayoutRetryLog> PayoutRetryLog { get; set; }
        public DbSet<PayoutStatus> PayoutStatus { get; set; }

        public PayoutDbContext(DbContextOptions<PayoutDbContext> options)
            : base(options)
        {
            //
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Commission>()
                .HasIndex(u=> new { u.TenantId, u.PartnerId })
                .HasDatabaseName("IX_Commission_TenantId_PartnerId");  

            modelBuilder.Entity<PaymentLimit>()
                .HasIndex(u => u.TenantId) 
                .HasDatabaseName("IX_PaymentLimit_TenantId");

            modelBuilder.Entity<Domain.Aggregates.PayoutAggregates.Payout>()
                 .HasIndex(p => new { p.TenantId, p.PartnerId,p.StatusId })
                 .HasDatabaseName("IX_Payout_TenantId_PartnerId_StatusId");

            modelBuilder.Entity<PayoutAuditLog>()
                .HasIndex(u => u.Id)
                .HasDatabaseName("IX_PayoutAuditLog_Id");

            modelBuilder.Entity<PayoutCurrency>()
               .HasIndex(p => new { p.Id, p.Code })
               .HasDatabaseName("IX_PayoutCurrency_Id_Code");

            modelBuilder.Entity<PayoutHistory>()
               .HasIndex(p => new { p.Id })
               .HasDatabaseName("IX_PayoutHistory_Id");

            modelBuilder.Entity<PayoutPaymentMethod>()
                 .HasIndex(p => new { p.Id, p.Name })
                 .HasDatabaseName("IX_PayoutPaymentMethod_Id_Name");


            modelBuilder.Entity<PayoutRetryLog>()
                 .HasIndex(p => new { p.Id })
                 .HasDatabaseName("IX_PayoutRetryLog_Id");


            modelBuilder.Entity<PayoutStatus>()
                 .HasIndex(p => new { p.Id,p.Name })
                 .HasDatabaseName("IX_PayoutStatus_Id_Name");

        }

    }
}
