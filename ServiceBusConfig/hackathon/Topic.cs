using Azure.Messaging.ServiceBus.Administration;

namespace SbConfiguration;
public class Topic : Queue
{
    public Subscription[] Subscriptions { get; set; } = new Subscription[0];
}