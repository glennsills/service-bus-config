namespace QueueTopicComposer.Model
{
    public class BaseQueueProperties
    {
        public string Name { get; set; } = string.Empty;
        public int MaxDeliveryCount { get; set; } = 1;
        public int MessageTimeToLiveInDays { get; set; } = 365;
        public int MessageLockDurationInSeconds { get; set; } = 15;
        public int DaysUntilAutoDelete { get; set; } = 10;
        public bool DeadLetteringEnabled { get; set; } = false;
        public bool SessionsEnabled { get; set; } = false;
        public bool MessageForwardingEnabled { get; set; } = false;

    }
}