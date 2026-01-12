using MediatR; 
using Partner.Application.Responses;
using Partner.Infrastructure.Contracts; 

namespace Partner.Application.Features.Merchants.Commands
{
    public class CreatePartnerCommandHandler : IRequestHandler<CreatePartnerCommand, GeneralResponse<int>>
    {
        private readonly IPartnerRepository _partnerRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreatePartnerCommandHandler(
            IPartnerRepository partnerRepository,
            IUnitOfWork unitOfWork)
        {
            _partnerRepository = partnerRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<GeneralResponse<int>> Handle(CreatePartnerCommand request, CancellationToken cancellationToken)
        {
            return null;
        }

    }

}