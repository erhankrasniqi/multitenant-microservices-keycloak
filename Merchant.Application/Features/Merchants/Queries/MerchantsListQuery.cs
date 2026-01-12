using MediatR;
using Merchant.Application.ReadModels.Merchants;
using Merchant.Application.Responses; 

namespace Merchant.Application.Features.Merchants.Queries
{
    public class MerchantsListQuery : IRequest<GeneralResponse<IEnumerable<MerchantsReadModel>>>
    {
        //
    }
}