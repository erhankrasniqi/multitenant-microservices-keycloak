using Analytics.Infrastructure.Contracts;
using MediatR;
using Analytics.Application.Responses; 

namespace Analytics.Application.Features.Merchants.Commands
{
    public class CreateAnaLyticsCommandHandler : IRequestHandler<CreateAnaLyticsCommand, GeneralResponse<int>>
    {
        private readonly IAnalyticsRepository _analyticsRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateAnaLyticsCommandHandler(
            IAnalyticsRepository  analyticsRepository,
            IUnitOfWork unitOfWork)
        {
            _analyticsRepository =  analyticsRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<GeneralResponse<int>> Handle(CreateAnaLyticsCommand request, CancellationToken cancellationToken)
        {
            return null;
        }

    }

}