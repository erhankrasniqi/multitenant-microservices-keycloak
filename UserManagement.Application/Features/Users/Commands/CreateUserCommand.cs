using MediatR;
using UserManagement.Application.ReadModels.Users;
using UserManagement.Application.Responses;

namespace UserManagement.Application.Features.Users.Commands
{
    public class CreateUserCommand : IRequest<GeneralResponse<int>>
    {
        public string TenantId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public AddressReadModel Address { get; set; }  
    } 
}
