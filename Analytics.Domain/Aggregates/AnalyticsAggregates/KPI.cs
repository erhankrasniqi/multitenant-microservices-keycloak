using SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analytics.Domain.Aggregates.AnalyticsAggregates
{
    // Për ruajtjen e metrikave të biznesit (KPI)
    public class KPI : AggregateRoot<int>
    {
        public string Name { get; set; } = default!;
        public DateTime Date { get; set; }
        public decimal Value { get; set; }
        public string Description { get; set; } = default!;
    }

}
