using MediatR;
using Analytics.Application.Responses; 

namespace Analytics.Application.Features.Merchants.Commands
{
    public class CreateAnaLyticsCommand : IRequest<GeneralResponse<int>>
    {
        public string Name { get; private set; } = default!;
        public string Email { get; private set; } = default!;
        public string PhoneNumber { get; private set; } = default!;
        public string CreatedBy { get; private set; } = default!; // KeycloakId
        public bool OnboardingCompleted { get; private set; } 
    }
}
