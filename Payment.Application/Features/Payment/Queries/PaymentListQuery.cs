using MediatR;
using Payment.Application.ReadModels.Merchants;
using Payment.Application.Responses; 

namespace Payment.Application.Features.Merchants.Queries
{
    public class PaymentListQuery : IRequest<GeneralResponse<IEnumerable<PaymentReadModel>>>
    {
        //
    }
}