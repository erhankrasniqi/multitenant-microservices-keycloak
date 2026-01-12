using MediatR;
using Partner.Application.ReadModels.Partners;
using Partner.Application.Responses; 

namespace Partner.Application.Features.Partners.Queries
{
    public class PartnerListQuery : IRequest<GeneralResponse<IEnumerable<PartnerReadModel>>>
    {
        //
    }
}