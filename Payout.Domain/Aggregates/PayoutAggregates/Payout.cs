using SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payout.Domain.Aggregates.PayoutAggregates
{
    public class Payout : AggregateRoot<int>
    {
        public int PartnerId { get; set; } // Partneri ose Merchant-i që merr pagesën
        public decimal Amount { get; set; } // Shuma që do paguhet
        public string TenantId { get; set; }
        public int CurrencyId { get; set; }
        public PayoutCurrency Currency { get; set; }

        public DateTime RequestedAt { get; set; } = DateTime.UtcNow; // Kur u kërkua payout
        public DateTime? ProcessedAt { get; set; } // Kur u përfundua

        public int StatusId { get; set; }
        public PayoutStatus Status { get; set; }

        public int PayoutPaymentMethodId { get; set; }  
        public PayoutPaymentMethod PayoutPaymentMethod { get; set; } 
        public string ReferenceNumber { get; set; } // Numri i referencës së pagesës (nëse aplikohet)
    }

}
