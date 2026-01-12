using MediatR;
using Payout.Application.ReadModels.Merchants;
using Payout.Application.Responses;

namespace Payout.Application.Features.Merchants.Queries
{
    public class PayoutListQuery : IRequest<GeneralResponse<IEnumerable<PayoutReadModel>>>
    {
        //
    }
}