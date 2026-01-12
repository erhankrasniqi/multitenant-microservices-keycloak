using MediatR;
using Microsoft.AspNetCore.Authorization; 
using Microsoft.AspNetCore.Mvc; 
using Partner.Application.Features.Partners.Queries; 
using Partner.Application.ReadModels.Partners;
using Partner.Application.Responses;

namespace Partner.API.Controllers
{
    [Authorize(Roles = "partner,admin")]
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PartnerController : DefaultController
    {
        public PartnerController(IMediator mediator)
            : base(mediator)
        {
            //
        }
         

        [HttpGet]
        public async Task<GeneralResponse<IEnumerable<PartnerReadModel>>> GetPartners()
        {
            return await Mediator.Send(new PartnerListQuery()).ConfigureAwait(false);
        } 

         
    }
}
