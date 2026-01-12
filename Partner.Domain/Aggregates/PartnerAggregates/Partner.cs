using SharedKernel;

namespace Partner.Domain.Aggregates.PartnerAggregates
{
    public class Partner : AggregateRoot<int>
    {
        public string Name { get; set; }
        public string PartnerCode { get; set; }
        public string BusinessType { get; set; }
        public string TenantId { get; set; }
    public PartnerAddress Address { get; set; }
        public ContactInfo ContactInfo { get; set; }

        public ICollection<PartnerUser> Users { get; set; }
        public ICollection<PartnerMerchant> Merchants { get; set; }
        public ICollection<PartnerPaymentPreference> PaymentPreferences { get; set; }
    }

}
