using SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Domain.Aggregates.PaymentAggregates
{
    public class Provider : AggregateRoot<int>
    {
        public string Name { get; set; } = default!;
        public string DeviceId { get; set; } = default!;  
        public string ContactEmail { get; set; }
        public string WebsiteUrl { get; set; }
        public bool IsActive { get; set; } = true;
    }

}
