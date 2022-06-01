namespace SbConfiguration;
public class Queue
{
    public string Name { get; set; } = string.Empty;
    public int DaysUntilAutoDelete {get;set;} = 10;
    public int LockDurationInSeconds {get;set;} = 15;
    public int MaxDeliveryCount {get;set;} = 1;
    public int MaxSizeInMegabytes {get;set;} = 2048;
    public bool DeadLetteringEnabled {get;set;} = false;
}