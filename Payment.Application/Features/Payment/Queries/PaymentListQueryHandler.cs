

using MediatR; 
using Payment.Application.Responses;  
using Payment.Application.ReadModels.Merchants; 
using Payment.Infrastructure.Contracts;

namespace Payment.Application.Features.Merchants.Queries
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
