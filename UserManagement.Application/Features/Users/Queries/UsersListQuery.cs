using MediatR;
using UserManagement.Application.ReadModels.User;
using UserManagement.Application.Responses;

namespace UserManagement.Application.Features.Users.Queries
{
    public class UsersListQuery : IRequest<GeneralResponse<IEnumerable<UserReadModel>>>
    {
        //
    }
}