using Analytics.Application.ReadModels.Merchants;
using MediatR; 
using Analytics.Application.Responses; 

namespace Analytics.Application.Features.Merchants.Queries
{
    public class AnaLyticsListQuery : IRequest<GeneralResponse<IEnumerable<AnalyticsReadModel>>>
    {
        //
    }
}