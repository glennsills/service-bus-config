using Azure.Messaging.ServiceBus.Administration;

namespace SbConfiguration;
public class Topic
{
    public string Name { get; set; } = string.Empty;
    public int DaysUntilAutoDelete {get;set;} = 10;
    public int MaxSizeInMegabytes {get;set;} = 2048;
    public Subscription[] Subscriptions { get; set; } = new Subscription[0];
}