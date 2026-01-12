

using Analytics.Application.ReadModels.Merchants;
using Analytics.Infrastructure.Contracts;
using MediatR; 
using Analytics.Application.Responses;
using Analytics.Application.Features.Merchants.Queries;

namespace Analytics.Application.Features.Merchants.Queries
{
    public class AnaLyticsListQueryHandler : IRequestHandler<AnaLyticsListQuery, GeneralResponse<IEnumerable<AnalyticsReadModel>>>
    {
        private readonly IAnalyticsRepository _merchantRepository;

        public AnaLyticsListQueryHandler(IAnalyticsRepository merchantRepository)
        {
            _merchantRepository = merchantRepository;
        }

        public async Task<GeneralResponse<IEnumerable<AnalyticsReadModel>>> Handle(AnaLyticsListQuery query, CancellationToken cancellationToken)
        {
            return null;
        }

    }
}
