using SharedKernel; 

namespace UserManagement.Domain.Aggregates.UsersAggregates
{
    public class UserRole : AggregateRoot<int>
    {
        public int UserId { get; set; }
        public int RoleId { get; set; } 
        public Users User { get; set; }
        public Role Role { get; set; }

        public static UserRole Create(int userId, int roleId)
        {
            return new UserRole
            {
                UserId = userId,
                RoleId = roleId,
            };
        }
    }
}
