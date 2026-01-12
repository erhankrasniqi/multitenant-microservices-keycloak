using MediatR;
using Microsoft.AspNetCore.Authorization; 
using Microsoft.AspNetCore.Mvc;
using Payment.Application.Features.Payment.Queries;
using Payment.Application.ReadModels.Payment;
using Payment.Application.Responses;

namespace Payment.API.Controllers
{
    [Authorize(Roles = "payment,admin")]
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PaymentController : DefaultController
    {
        public PaymentController(IMediator mediator)
            : base(mediator)
        {
            //
        }
         

        [HttpGet]
        public async Task<GeneralResponse<IEnumerable<PaymentReadModel>>> GetPayments()
        {
            return await Mediator.Send(new PaymentListQuery()).ConfigureAwait(false);
        } 

         
    }
}
