using Analytics.Domain.Aggregates.AnalyticsAggregates; 
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analytics.Infrastructure.Database
{
    public class TapyPayAnalyticsDbContext : DbContext
    {
        public DbSet<AnalyticsEventRecord> AnalyticsEventRecords { get; set; }
        public DbSet<Alert> Alerts { get; set; }
        public DbSet<EventType> EventTypes { get; set; }
        public DbSet<KPI> KPIs { get; set; }
        public DbSet<PaymentAnalytics> PaymentAnalytics { get; set; }
        public DbSet<PaymentMethodAnalytics> PaymentMethodAnalytics { get; set; }
        public DbSet<PayoutAnalytics> PayoutAnalytics { get; set; }
        public DbSet<UserActivityAnalytics> UserActivityAnalytics { get; set; }

        public TapyPayAnalyticsDbContext(DbContextOptions<TapyPayAnalyticsDbContext> options)
            : base(options)
        {
            //
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Alert>()
                .HasIndex(p => new { p.Id,p.TenantId })
                .HasDatabaseName("IX_Alert_Id_TenantId");

            modelBuilder.Entity<AnalyticsEventRecord>()
              .HasIndex(p => new { p.Id, p.TenantId })
              .HasDatabaseName("IX_AnalyticsEventRecord_Id_TenantId");

            modelBuilder.Entity<EventType>()
              .HasIndex(p => new { p.Id, p.Name })
              .HasDatabaseName("IX_EventType_Id_Name");

            modelBuilder.Entity<KPI>()
               .HasIndex(p => new { p.Id, p.Name })
               .HasDatabaseName("IX_KPI_Id_Name");


            modelBuilder.Entity<PaymentAnalytics>()
               .HasIndex(p => new { p.Id, p.TenantId })
               .HasDatabaseName("IX_PaymentAnalytics_Id_Name_TenantId");


            modelBuilder.Entity<PaymentMethodAnalytics>()
               .HasIndex(p => new { p.Id, p.TenantId })
               .HasDatabaseName("IX_PaymentMethodAnalytics_Id_Name_TenantId");

            modelBuilder.Entity<PayoutAnalytics>()
             .HasIndex(p => new { p.Id, p.TenantId })
             .HasDatabaseName("IX_PayoutAnalytics_Id_Name_TenantId");

            modelBuilder.Entity<PayoutAnalytics>()
                .HasIndex(p => new { p.Id, p.TenantId })
                .HasDatabaseName("IX_PayoutAnalytics_Id_Name_TenantId");
                    }

    }
}
