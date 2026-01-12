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
        }
    }
}
