using MediatR; 
using Payment.Application.Responses;
using Payment.Infrastructure.Contracts;
using Payment.Application.Responses;
using Payment.Application.Features.Merchants.Commands;

namespace Payment.Application.Features.Merchants.Commands
{
    public class CreatePaymentCommandHandler : IRequestHandler<CreatePaymentCommand, GeneralResponse<int>>
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreatePaymentCommandHandler(
            IPaymentRepository paymentRepository,
            IUnitOfWork unitOfWork)
        {
            _paymentRepository = paymentRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<GeneralResponse<int>> Handle(CreatePaymentCommand request, CancellationToken cancellationToken)
        {
            return null;
        }

    }

}