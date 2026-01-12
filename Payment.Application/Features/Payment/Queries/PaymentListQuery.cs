using MediatR; 
using Payment.Application.ReadModels.Payment;
using Payment.Application.Responses; 

namespace Payment.Application.Features.Payment.Queries
{
    public class PaymentListQuery : IRequest<GeneralResponse<IEnumerable<PaymentReadModel>>>
    {
        //
    }
}