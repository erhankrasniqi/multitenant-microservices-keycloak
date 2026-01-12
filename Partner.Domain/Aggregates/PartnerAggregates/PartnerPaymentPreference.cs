using SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Partner.Domain.Aggregates.PartnerAggregates
{
    public class PartnerPaymentPreference : AggregateRoot<int>
    {
        public int PartnerId { get; set; }
        public Partner Partner { get; set; }
        public string CurrencyCode { get; set; }         // vjen nga PaymentService
        public Guid PaymentMethodId { get; set; }        // vjen nga PaymentService
        public bool IsPreferred { get; set; }
    }

}
