namespace SbConfiguration;

public class Queue : BaseQueue
{
    public bool DuplicateDetectionEnabled {get;set;} = false;
    public bool PartitioningEnabled {get;set;} = false;
    public int MaxSizeInMegabytes { get; set; } = 2048;
}