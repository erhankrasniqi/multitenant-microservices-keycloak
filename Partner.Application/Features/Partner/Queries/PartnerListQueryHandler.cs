

using MediatR;
using Partner.Application.ReadModels.Merchants;
using Partner.Application.Responses;
using Partner.Domain.Aggregates.PartnerAggregates;
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
