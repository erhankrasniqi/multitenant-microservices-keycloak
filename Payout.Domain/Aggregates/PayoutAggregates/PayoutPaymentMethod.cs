using SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payout.Domain.Aggregates.PayoutAggregates
{
    public class PayoutPaymentMethod : AggregateRoot<int>
    {
        public string Name { get; set; } = default!;   // Emri i metodës, p.sh. "Credit Card", "NFC"
        public string? Description { get; set; }       // Përshkrim opsional
        public bool IsActive { get; set; } = true;     // Nëse metoda është aktive
    }

}
