using MediatR; 
using Microsoft.AspNetCore.Mvc;

namespace Analytics.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        protected readonly IMediator Mediator;

    public DefaultController(IMediator mediator)
    {
        Mediator = mediator;
    }
}
}