using SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payout.Domain.Aggregates.PayoutAggregates
{
    public class PayoutCurrency : AggregateRoot<int>
    {
        public string Code { get; set; } = default!; // e.g., EUR, USD
        public string Symbol { get; set; } = default!; // e.g., €, $
        public string Name { get; set; } = default!;   // Euro, Dollar

        public ICollection<Payout> Payments { get; set; } = new List<Payout>();
    }
}
