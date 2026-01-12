using Microsoft.EntityFrameworkCore;
using Payment.Domain.Aggregates.PaymentAggregates;

namespace Payment.Infrastructure.Database
{
    public class PaymentDbContext : DbContext
    {
        public DbSet<PaymentMethod> PaymentMethods { get; set; }    
        public DbSet<Payments> Payments { get; set; }    
        public DbSet<Currency> Currency { get; set; }    
        public DbSet<PaymentLimit> PaymentLimit { get; set; }    
        public DbSet<PaymentStatus> PaymentStatus { get; set; }    
        public DbSet<PaymentStatusHistory> PaymentStatusHistory { get; set; }    
        public DbSet<Provider> Provider { get; set; }    
        public DbSet<TransactionLog> TransactionLog { get; set; }    

        public PaymentDbContext(DbContextOptions<PaymentDbContext> options)
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
