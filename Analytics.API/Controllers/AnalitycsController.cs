using MediatR; 
using Analytics.Application.Features.Merchants.Commands;
using Analytics.Application.Features.Merchants.Queries;
using Analytics.Application.ReadModels.Merchants;
using Analytics.Application.Responses;
using Microsoft.AspNetCore.Authorization; 
using Microsoft.AspNetCore.Mvc; 

namespace Analytics.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AnalitycsController : DefaultController
    {
        public AnalitycsController(IMediator mediator)
            : base(mediator)
        {
            //
        }
         

        [HttpGet]
        public async Task<GeneralResponse<IEnumerable<AnalyticsReadModel>>> GetMerchants()
        {
            return await Mediator.Send(new AnaLyticsListQuery()).ConfigureAwait(false);
        }


        [HttpPost]
        public async Task<GeneralResponse<int>> UserMerchant([FromBody] CreateAnaLyticsCommand command)
        {
            return await Mediator.Send(command).ConfigureAwait(false);
        }

    }
}
