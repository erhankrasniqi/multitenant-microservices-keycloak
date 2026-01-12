using MediatR;
using Payment.Application.ReadModels.Payment;
using Payment.Application.Responses;   
using Payment.Infrastructure.Contracts;

namespace Payment.Application.Features.Payment.Queries
{
    public class PaymentListQueryHandler : IRequestHandler<PaymentListQuery, GeneralResponse<IEnumerable<PaymentReadModel>>>
    {
        private readonly IPaymentRepository _paymentRepository;

        public PaymentListQueryHandler(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        public async Task<GeneralResponse<IEnumerable<PaymentReadModel>>> Handle(PaymentListQuery query, CancellationToken cancellationToken)
        {
            return null;
        }

    }
}
