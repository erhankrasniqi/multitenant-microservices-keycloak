using MediatR;
using Merchant.Application.ReadModels.Merchants;
using Merchant.Application.Responses; 

namespace Merchant.Application.Features.Merchants.Commands
{
    public class CreateMerchantCommand : IRequest<GeneralResponse<int>>
    {
        public string Name { get; private set; } = default!;
        public string Email { get; private set; } = default!;
        public string PhoneNumber { get; private set; } = default!;
        public string CreatedBy { get; private set; } = default!; // KeycloakId
        public bool OnboardingCompleted { get; private set; }
        public AddressReadModel AddressReadModel { get; set; }
        public MerchantDetailsReadModel MerchantDetailsReadModel { get; set; }
        public MerchantStatusReadModel MerchantStatusReadModel { get; set; }
    }
}
