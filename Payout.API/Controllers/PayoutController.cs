using MediatR;
using Microsoft.AspNetCore.Authorization; 
using Microsoft.AspNetCore.Mvc;
using Payout.API.Controllers;
using Payout.Application.Features.Payout.Queries;
using Payout.Application.ReadModels.Payout;
using Payout.Application.Responses;

namespace Payment.API.Controllers
{
    [Authorize(Roles = "payout,admin")]
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
