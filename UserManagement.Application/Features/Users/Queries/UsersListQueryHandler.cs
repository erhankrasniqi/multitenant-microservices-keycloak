using MediatR;
using UserManagement.Application.ReadModels.User;
using UserManagement.Application.ReadModels.Users;
using UserManagement.Application.Responses; 
using UserManagement.Infrastructure.Contracts;

namespace UserManagement.Application.Features.Users.Queries
{
    public class UsersListQueryHandler : IRequestHandler<UsersListQuery, GeneralResponse<IEnumerable<UserReadModel>>>
    {
        private readonly IUserRepository _userRepository;

        public UsersListQueryHandler(IUserRepository customerRepository)
        {
            _userRepository = customerRepository;
        }

        public async Task<GeneralResponse<IEnumerable<UserReadModel>>> Handle(UsersListQuery query, CancellationToken cancellationToken)
        {
            IEnumerable<Domain.Aggregates.UsersAggregates.Users> users = await _userRepository
                .GetUserwithAddress(cancellationToken: cancellationToken)
                .ConfigureAwait(false);

            IEnumerable<UserReadModel> readModel = [];

            if (users.Any())
            {
                readModel = users.Select(x => {
                    var firstAddress = x.Addresses?.FirstOrDefault();
                    return new UserReadModel
                    {
                        Id = x.Id,
                        KeycloakId = x.KeycloakId,
                        FirstName = x.FirstName,
                        LastName = x.LastName,
                        Address = firstAddress != null ? new AddressReadModel
                        {
                            Street = firstAddress.Street,
                            City = firstAddress.City,
                            Region = firstAddress.Region,
                            PostalCode = firstAddress.PostalCode,
                            Country = firstAddress.Country
                        } : null
                    };
                }).ToList();

            }

            return new GeneralResponse<IEnumerable<UserReadModel>>
            {
                Success = true,
                Message = "User list.",
                Result = readModel
            };
        }

    }
}
