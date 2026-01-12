
using UserManagement.Application.ReadModels.Users;

namespace UserManagement.Application.ReadModels.User
{
    public class UserReadModel
    {
        public int Id { get; set; }
        public Guid KeycloakId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; } 
        public AddressReadModel Address { get; set; }
    }
}
