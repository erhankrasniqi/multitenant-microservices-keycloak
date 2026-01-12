using MediatR;
using Partner.Application.Features.Partners.Queries;
using Partner.Application.ReadModels.Partners;
using Partner.Application.Responses; 
using Partner.Infrastructure.Contracts;

namespace Partner.Application.Features.Merchants.Queries
{
    public class PartnerListQueryHandler : IRequestHandler<PartnerListQuery, GeneralResponse<IEnumerable<PartnerReadModel>>>
    {
        private readonly IPartnerRepository _partnerRepository;

        public PartnerListQueryHandler(IPartnerRepository partnerRepository)
        {
            _partnerRepository = partnerRepository;
        }

        public async Task<GeneralResponse<IEnumerable<PartnerReadModel>>> Handle(PartnerListQuery query, CancellationToken cancellationToken)
        {
            return null;
        }

    }
}
