using MediatR; 
using UserManagement.Application.Responses; 
using UserManagement.Infrastructure.Contracts;

namespace UserManagement.Application.Features.Users.Commands
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, GeneralResponse<int>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateUserCommandHandler(
            IUserRepository userRepository,
            IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<GeneralResponse<int>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);

            var user = Domain.Aggregates.UsersAggregates.Users.Create(
                null,
                request.FirstName,
                request.LastName,
                request.Address.PostalCode,
                request.Address.Street,
                request.Address.City,
                request.Address.Region,
                request.Address.Country
            );

            await _userRepository.Add(user, cancellationToken);
            await _unitOfWork.Save(cancellationToken);

            return new GeneralResponse<int>
            {
                Success = true,
                Message = "User created successfully.",
                Result = user.Id
            };
        }

    }

}