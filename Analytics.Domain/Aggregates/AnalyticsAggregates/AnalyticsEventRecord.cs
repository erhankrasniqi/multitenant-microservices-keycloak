using SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analytics.Domain.Aggregates.AnalyticsAggregates
{
    // Regjistrim i eventeve që vijnë nga shërbimet e tjera
    public class AnalyticsEventRecord : AggregateRoot<int>
    {
        public int EventTypeId { get; set; } = default!;   
        public EventType EventType { get; set; } = default!;   
        public string EventDataJson { get; set; } = default!; // Të dhëna raw JSON të eventit
    }
}
