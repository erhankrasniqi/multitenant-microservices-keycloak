 
using MediatR; 
using Analytics.Application.Responses;
using Analytics.Application.ReadModels;

namespace Analytics.Application.Features.Analytics.Queries
{
    public class AnaLyticsListQuery : IRequest<GeneralResponse<IEnumerable<AnalyticsReadModel>>>
    {
        //
    }
}