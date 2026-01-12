

using MediatR;
using Merchant.Application.ReadModels.Merchants;
using Merchant.Application.Responses;
using Merchant.Domain.Aggregate.MerchantAggregates;
using Merchant.Infrastructure.Contracts;

namespace Merchant.Application.Features.Merchants.Queries
{
    public class MerchantsListQueryHandler : IRequestHandler<MerchantsListQuery, GeneralResponse<IEnumerable<MerchantsReadModel>>>
    {
        private readonly IMerchantRepository _merchantRepository;

        public MerchantsListQueryHandler(IMerchantRepository merchantRepository)
        {
            _merchantRepository = merchantRepository;
        }

        public async Task<GeneralResponse<IEnumerable<MerchantsReadModel>>> Handle(MerchantsListQuery query, CancellationToken cancellationToken)
        {
            IEnumerable<Domain.Aggregate.MerchantAggregates.Merchant> merchants = await _merchantRepository
                .GetMerchants(cancellationToken: cancellationToken)
                .ConfigureAwait(false);

            IEnumerable<MerchantsReadModel> readModel = [];

            if (merchants.Any())
            {
                //readModel = merchants.Select(x => { 

                //    return new MerchantsReadModel
                //    {
                //        Id = x.Id,
                //        KeycloakId = x.KeycloakId,
                //        FirstName = x.FirstName,
                //        LastName = x.LastName,
                //        Address = firstAddress != null ? new AddressReadModel
                //        {
                //            Street = firstAddress.Street,
                //            City = firstAddress.City,
                //            Region = firstAddress.Region,
                //            PostalCode = firstAddress.PostalCode,
                //            Country = firstAddress.Country
                //        } : null
                //    };
                //}).ToList();

            }

            return new GeneralResponse<IEnumerable<MerchantsReadModel>>
            {
                Success = true,
                Message = "User list.",
                Result = readModel
            };
        }

    }
}
