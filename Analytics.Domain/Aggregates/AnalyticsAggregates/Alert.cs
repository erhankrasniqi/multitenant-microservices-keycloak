using SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analytics.Domain.Aggregates.AnalyticsAggregates
{
    // Për regjistrimin e alarmeve (alerts) në rast anomalish ose ndonjë ngjarjeje
    public class Alert : AggregateRoot<int>
    {
        public string AlertType { get; set; } = default!;
        public string Message { get; set; } = default!;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public bool IsResolved { get; set; } = false;
    }
}
