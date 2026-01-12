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


            modelBuilder.Entity<Currency>()
                 .HasIndex(p => new { p.Id, p.Name })
                 .HasDatabaseName("IX_Currency_Id_Name"); 
            
            modelBuilder.Entity<PaymentLimit>()
                 .HasIndex(p => new { p.Id })
                 .HasDatabaseName("IX_PaymentLimit_Id");


            modelBuilder.Entity<Payments>()
                 .HasIndex(p => new { p.Id,p.MerchantId, p.TenantId })
                 .HasDatabaseName("IX_Payments_Id_MerchantId_TenantId");


            modelBuilder.Entity<PaymentStatus>()
                 .HasIndex(p => new { p.Id, p.Name })
                 .HasDatabaseName("IX_PaymentStatus_Id_Name");


            modelBuilder.Entity<PaymentStatusHistory>()
                 .HasIndex(p => new { p.Id,p.PaymentId,p.StatusId })
                 .HasDatabaseName("IX_PaymentLimit_Id_PaymentId_StatusId");


            modelBuilder.Entity<Provider>()
                 .HasIndex(p => new { p.Id, p.Name, p.DeviceId })
                 .HasDatabaseName("IX_Provider_Id_Name_DeviceId");

            modelBuilder.Entity<TransactionLog>()
               .HasIndex(p => new { p.PaymentId, p.TenantId })
               .HasDatabaseName("IX_TransactionLog_PaymentIde_TenantId");

        }

    }
}
