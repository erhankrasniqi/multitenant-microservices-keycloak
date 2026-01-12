
using Payout.Application.Responses;
using MediatR;
using Payout.Application.Features.Merchants.Queries;
using Payout.Infrastructure.Contracts;
using Payout.Application.ReadModels.Merchants;

namespace Payment.Application.Features.Merchants.Queries
{
    public class PayoutListQueryHandler : IRequestHandler<PayoutListQuery, GeneralResponse<IEnumerable<PayoutReadModel>>>
    {
        private readonly IPayoutRepository _payoutRepository;

        public PayoutListQueryHandler(IPayoutRepository payoutRepository)
        {
            _payoutRepository = payoutRepository;
        }

        public async Task<GeneralResponse<IEnumerable<PayoutReadModel>>> Handle(PayoutListQuery query, CancellationToken cancellationToken)
        {
            return null;
        }

    }
}
