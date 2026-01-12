using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using TapyPay.Infrastructure.Contracts.DistributedMessageBroker;
using TapyPay.Infrastructure.Contracts.DistributedMessageBroker.Models;
using TapyPay.Infrastructure.MessageBroker.Configuration;
using UserManagement.Infrastructure;

IServiceCollection services = new ServiceCollection();

string rabbitMqSection = "RabbitMqConfiguration:";
string host = "localhost";
int port = 5672;
string username = "guest";
string password = "guest";
string clientProvidedName = string.Empty;
string virtualHost = "/";
RabbitMqSettings rabbitMqSettings = new(host, port, username, password, clientProvidedName, virtualHost);

services.RegisterMessageBrokerAndNotifications(rabbitMqSettings);

IServiceProvider serviceProvider = services.BuildServiceProvider();

IMessageBroker messageBroker = serviceProvider.GetRequiredService<IMessageBroker>();

IList<string> queues = new List<string>() { "new-user-creation" };
GeneralConsumer consumer = new()
{
    Queues = queues,
    Action = ConsumeDataFromQueue
};

await messageBroker.StartConsuming(consumer).ConfigureAwait(false);

while(true)
{
    //
}

void ConsumeDataFromQueue(string item)
{
    Console.WriteLine("===>>> NEW MESSAGE RECEIVED");
    Console.WriteLine("");
    Console.WriteLine(item);
    Console.WriteLine("");
    Console.WriteLine("============================================");
    Console.WriteLine("");
}
