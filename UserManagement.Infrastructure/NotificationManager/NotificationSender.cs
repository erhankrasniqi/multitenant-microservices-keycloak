using SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TapyPay.Infrastructure.Contracts.DistributedMessageBroker.Models;
using TapyPay.Infrastructure.Contracts.DistributedMessageBroker;
using UserManagement.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using UserManagement.Domain.Aggregates.UsersAggregates;

namespace UserManagement.Infrastructure.NotificationManager
{
    public class NotificationSender(TapyPayDbContext dbContext, IMessageBroker messageBroker) : INotifier
    {
        private readonly TapyPayDbContext _dbContext = dbContext;
        private readonly IMessageBroker _messageBroker = messageBroker;

        public async Task Notify<TKey>(IAggregateRoot<TKey> notificationItem, string channelName)
        {
            TKey id = notificationItem.Id;

            var user = await _dbContext.Users.SingleOrDefaultAsync(x => x.Id == int.Parse(id.ToString())).ConfigureAwait(false);

            GeneralQueueMessage<Users> message = new()
            {
                Queue = new GeneralQueue { Name = channelName },
                Body = user
            };

            await _messageBroker.SendObject(message).ConfigureAwait(false);

            /*
            GeneralQueueMessage message = new()
            {
                Queue = new GeneralQueue { Name = channelName },
                Body = id.ToString()
            };

            await _messageBroker.SendString(message).ConfigureAwait(false);
            */
        }
    }
}
