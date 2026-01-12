 

namespace Infrastructure.Messaging.Events
{
    public class UserRegisteredEvent
    {
        public Guid UserId { get; set; }
        public string Email { get; set; } = default!;
        public string FullName { get; set; } = default!;
    }
}
