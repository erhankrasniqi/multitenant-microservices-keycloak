using SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analytics.Domain.Aggregates.AnalyticsAggregates
{
    public class EventType : AggregateRoot<int>
    {
        public string Name { get; set; } = default!;    
        public string Description { get; set; } = default!;  
    }
}
