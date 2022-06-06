using Azure.Messaging.ServiceBus.Administration;

using Microsoft.Extensions.Configuration;

namespace SbConfiguration;
class Program
{
    static async Task Main(string[] args)
    {

        var configurationBuilder = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json");

        if (Environment.GetEnvironmentVariable("Environment") == "Develop")
        {
            configurationBuilder.AddUserSecrets<Program>();
        }

        var config = configurationBuilder.Build();

        ServiceBusConfiguration serviceBusConfig = config.GetRequiredSection("ServiceBusConfiguration").Get<ServiceBusConfiguration>();

        var adminClient = new ServiceBusAdministrationClient(serviceBusConfig.ServiceBusConnection);

        var configurator = new ServiceBusConfigurator(adminClient, serviceBusConfig);

        await configurator.AssureAllQueuesAndTopics();
    }
}