using SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Domain.Aggregates.PaymentAggregates
{
    public class TransactionLog : AggregateRoot<int>
    {
        public Guid PaymentId { get; set; }
        public string Action { get; set; }            // p.sh. "Created", "Retry", "Failed"
        public string Message { get; set; }           // Përshkrimi
        public DateTime Timestamp { get; set; }
    }
}
