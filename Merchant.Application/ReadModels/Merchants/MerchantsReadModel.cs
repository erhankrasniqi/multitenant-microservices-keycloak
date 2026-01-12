
namespace Merchant.Application.ReadModels.Merchants
{
    public class MerchantsReadModel
    {
        public string Name { get; private set; } = default!;
        public string Email { get; private set; } = default!;
        public string PhoneNumber { get; private set; } = default!;

        public Guid AddressId { get; private set; }
        public Guid StatusId { get; private set; }

        public string CreatedBy { get; private set; } = default!; // KeycloakId
        public bool OnboardingCompleted { get; private set; }

        // Navigation properties
        public AddressReadModel Address { get; private set; } = default!;
        public MerchantStatusReadModel Status { get; private set; } = default!;
        public MerchantDetailsReadModel? Details { get; private set; }
        
    }
}
