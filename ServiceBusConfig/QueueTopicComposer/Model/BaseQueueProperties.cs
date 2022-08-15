using System;
using System.ComponentModel.DataAnnotations;
using Azure.Messaging.ServiceBus.Administration;
using QueueTopicComposer.Model.Validators;

namespace QueueTopicComposer.Model
{
    public class BaseQueueProperties
    {
        public Boolean EnablePartitioning { get; set; } = false;

        public string ForwardDeadLetteredMessagesTo { get; set; }

        public string ForwardTo { get; set; } = string.Empty;

        public EntityStatus Status { get; set; } = EntityStatus.Active;

        public bool EnableBatchedOperations { get; set; } = true;

        public int MaxDeliveryCount { get; set; } = 10;

        [Range(typeof (TimeSpan), "0:0:0:20", "7:0:0:0")]
        public TimeSpan DuplicateDetectionHistoryTimeWindow
        { get; set;
        } = TimeSpan.FromMinutes(1);

        public bool DeadLetteringOnMessageExpiration { get; set; } = false;

        [Range(typeof (TimeSpan), "0:0:5:0", "10675199.02:48:05.4775807")]
        public TimeSpan AutoDeleteOnIdle { get; set; } = TimeSpan.MaxValue;

        public TimeSpan DefaultMessageTimeToLive
        { get; set;
        } = System.TimeSpan.MaxValue;

        public bool RequiresSession { get; set; } = false;

        public bool RequiresDuplicateDetection { get; set; } = false;

        [Range(1, long.MaxValue)]
        public long MaxSizeInMegabytes { get; set; } = 1024;

        [Range(typeof (TimeSpan), "0:0:1", "0:5:0")]
        public TimeSpan LockDuration { get; set; } = TimeSpan.FromSeconds(60);

        [Required]
        [StringLength(260)]
        [QueueName]
        public string Name { get; set; } = string.Empty;

        [Range(1, long.MaxValue)]
        public long? MaxMessageSizeInKilobytes { get; set; }

        public string UserMetadata { get; set; }

        public bool MessageForwardingEnabled { get; set; } = false;
    }
}
