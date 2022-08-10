using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using gbsills.ServiceBusConfig.TestProgram;
using QueueTopicComposer;

await Host.CreateDefaultBuilder(args)
.ConfigureServices((hostContext, services) =>
{

	services.AddOptions<ServiceBusConfiguration>().Bind(hostContext.Configuration.GetSection("ServiceBusConfiguration"));
	services.AddHostedService<ConsoleHostedService>();
})
.RunConsoleAsync();
