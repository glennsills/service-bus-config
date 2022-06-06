using QueueTopicComposer.Model;

namespace QueueTopicComposer
{
    public class Queue : BaseQueueProperties
    {
        public bool DuplicateDetectionEnabled { get; set; } = false;
        public bool PartitioningEnabled { get; set; } = false;
        public int MaxSizeInMegabytes { get; set; } = 2048;
    }
}