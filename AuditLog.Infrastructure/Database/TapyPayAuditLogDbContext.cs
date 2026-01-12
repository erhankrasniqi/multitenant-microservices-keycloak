 
using Microsoft.EntityFrameworkCore;

namespace AuditLog.Infrastructure.Database
{
    public class TapyPayAuditLogDbContext : DbContext
    {
        public DbSet<AuditLog.Domain.Aggregates.AuditLogAggregates.AuditLog> AnalyticsEventRecords { get; set; }


        public TapyPayAuditLogDbContext(DbContextOptions<TapyPayAuditLogDbContext> options)
            : base(options)
        {
            //
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AuditLog.Domain.Aggregates.AuditLogAggregates.AuditLog>()
                .HasIndex(p => new { p.Id })
                .HasDatabaseName("IX_AuditLog_Id");


        }
    }
}