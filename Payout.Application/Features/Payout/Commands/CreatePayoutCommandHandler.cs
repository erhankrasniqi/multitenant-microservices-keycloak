using MediatR;
using Payout.Application.Responses;
using Payout.Infrastructure.Contracts;  

namespace Payout.Application.Features.Merchants.Commands
{
    public class CreatePayoutCommandHandler : IRequestHandler<CreatePayoutCommand, GeneralResponse<int>>
    {
        private readonly IPayoutRepository _payoutRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreatePayoutCommandHandler(
            IPayoutRepository payoutRepository,
            IUnitOfWork unitOfWork)
        {
            _payoutRepository = payoutRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<GeneralResponse<int>> Handle(CreatePayoutCommand request, CancellationToken cancellationToken)
        {
            return null;
        }

    }

}