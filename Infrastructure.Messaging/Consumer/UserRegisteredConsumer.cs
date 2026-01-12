using Infrastructure.Messaging.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Infrastructure.Contracts;

namespace Infrastructure.Messaging.Consumer
{
    //public class UserRegisteredConsumer : IConsumer<UserRegisteredEvent>
    //{
    //    private readonly IUserRepository _userRepository;

    //    public UserRegisteredConsumer(IUserRepository userRepository)
    //    {
    //        _userRepository = userRepository;
    //    }

    //    public async Task Consume(ConsumeContext<UserRegisteredEvent> context)
    //    {
    //        var eventMessage = context.Message;
             
    //        var user = new User
    //        {
    //            Id = eventMessage.UserId,
    //            Email = eventMessage.Email,
    //            FullName = eventMessage.FullName
    //        };

    //        await _userRepository.AddAsync(user);
    //        await _userRepository.SaveChangesAsync();
    //    }
    //}

}
