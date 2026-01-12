using MediatR;
using Microsoft.AspNetCore.Authorization; 
using Microsoft.AspNetCore.Mvc;
using Payout.API.Controllers;
using Payout.Application.Features.Merchants.Queries;
using Payout.Application.ReadModels.Merchants;
using Payout.Application.Responses;

namespace Payment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PayoutController : DefaultController
    {
        public PayoutController(IMediator mediator)
            : base(mediator)
        {
            //
        }
         

        [HttpGet]
        public async Task<GeneralResponse<IEnumerable<PayoutReadModel>>> GetPayouts()
        {
            return await Mediator.Send(new PayoutListQuery()).ConfigureAwait(false);
        } 

         
    }
}
