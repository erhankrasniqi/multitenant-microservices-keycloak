using MediatR;
using Partner.Application.ReadModels.Merchants;
using Partner.Application.Responses; 

namespace Partner.Application.Features.Merchants.Queries
{
    public class PartnerListQuery : IRequest<GeneralResponse<IEnumerable<PartnerReadModel>>>
    {
        //
    }
}