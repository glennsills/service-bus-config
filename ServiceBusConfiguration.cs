namespace SbConfiguration;

public class ServiceBusConfiguration 
{
    public string ServiceBusConnection {get;set;} = string.Empty;
    public Queue[] Queues {get;set;} = new Queue[0];
    public Topic []Topics {get;set;} =  new Topic[0];
}