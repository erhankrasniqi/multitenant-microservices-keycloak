using MediatR;
using Merchant.Application.Responses;
using Merchant.Infrastructure.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merchant.Application.Features.Merchants.Commands
{
    public class CreateMerchantCommandHandler : IRequestHandler<CreateMerchantCommand, GeneralResponse<int>>
    {
        private readonly IMerchantRepository _merchantRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateMerchantCommandHandler(
            IMerchantRepository merchantRepository,
            IUnitOfWork unitOfWork)
        {
            _merchantRepository = merchantRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<GeneralResponse<int>> Handle(CreateMerchantCommand request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);

            var merchant = Domain.Aggregate.MerchantAggregates.Merchant.Create(
                request.Name,
                request.Email,
                request.PhoneNumber,
                request.CreatedBy,
                request.OnboardingCompleted);

            await _merchantRepository.Add(merchant, cancellationToken);
            await _unitOfWork.Save(cancellationToken);

            return new GeneralResponse<int>
            {
                Success = true,
                Message = "Merchant created successfully.",
                Result = merchant.Id
            };
        }

    }

}