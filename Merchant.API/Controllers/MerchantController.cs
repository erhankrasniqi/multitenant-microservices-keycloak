using MediatR;
using Merchant.API.Controllers;
using Merchant.Application.Features.Merchants.Commands;
using Merchant.Application.Features.Merchants.Queries;
using Merchant.Application.ReadModels.Merchants;
using Merchant.Application.Responses;
using Microsoft.AspNetCore.Authorization; 
using Microsoft.AspNetCore.Mvc; 

namespace Merchant.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MerchantController : DefaultController
    {
        public MerchantController(IMediator mediator)
            : base(mediator)
        {
            //
        }
         

        [HttpGet]
        public async Task<GeneralResponse<IEnumerable<MerchantsReadModel>>> GetMerchants()
        {
            return await Mediator.Send(new MerchantsListQuery()).ConfigureAwait(false);
        }


        [HttpPost]
        public async Task<GeneralResponse<int>> UserMerchant([FromBody] CreateMerchantCommand command)
        {
            return await Mediator.Send(command).ConfigureAwait(false);
        }

    }
}
