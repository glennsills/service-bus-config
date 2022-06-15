using Azure.Messaging.ServiceBus.Administration;
using Microsoft.Extensions.Configuration;


namespace SbConfiguration;
class Program
{
    static async Task Main(string[] args)
    {
		var configurationManager = new ConfigurationManager();

        configurationManager.AddJsonFile("appsettings.json");

        if (Environment.GetEnvironmentVariable("Environment") == "Develop")
        {
            configurationManager.AddUserSecrets<Program>();
        }

        ServiceBusConfiguration serviceBusConfig = configurationManager.GetRequiredSection("ServiceBusConfiguration").Get<ServiceBusConfiguration>();

        var adminClient = new ServiceBusAdministrationClient(serviceBusConfig.ServiceBusConnection);

        var configurator = new ServiceBusConfigurator(adminClient, serviceBusConfig);

        await configurator.AssureAllQueuesAndTopics();
    }
}