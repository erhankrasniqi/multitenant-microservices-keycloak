using MediatR;
using Payout.Application.ReadModels.Payout;
using Payout.Application.Responses;

namespace Payout.Application.Features.Payout.Queries
{
    public class PayoutListQuery : IRequest<GeneralResponse<IEnumerable<PayoutReadModel>>>
    {
        //
    }
}