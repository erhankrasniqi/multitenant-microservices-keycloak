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
        }
    }
}
