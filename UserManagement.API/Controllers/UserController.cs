using MediatR;
using Microsoft.AspNetCore.Authorization; 
using Microsoft.AspNetCore.Mvc;
using UserManagement.Application.Features.Users.Commands;
using UserManagement.Application.Features.Users.Queries;
using UserManagement.Application.ReadModels.User;
using UserManagement.Application.Responses;

namespace UserManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController] 
    public class UserController : DefaultController
    {
        public UserController(IMediator mediator)
            : base(mediator)
        {
            //
        }

        [HttpGet]
        [Route("profile")]
        public IActionResult GetCurrentUser()
        {
            var userName = User.Identity?.Name;
            return Ok(new { Message = "Profili i përdoruesit aktual", User = userName });
        }

        [HttpGet]
        public async Task<GeneralResponse<IEnumerable<UserReadModel>>> GetUsers()
        {
            return await Mediator.Send(new UsersListQuery()).ConfigureAwait(false);
        } 

        [HttpPost]
        public async Task<GeneralResponse<int>> UserCreate([FromBody] CreateUserCommand command)
        {
            return await Mediator.Send(command).ConfigureAwait(false);
        }
    }
}
