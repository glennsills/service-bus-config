using System;
using System.ComponentModel.DataAnnotations;
using QueueTopicComposer.Model.Validators;

namespace QueueTopicComposer.Model
{
    public class BaseQueueProperties
    {
		[Required]
		[StringLength(260)]
        [QueueName]
		public string Name { get; set; } = string.Empty;

		[Required]
		[Range(typeof(TimeSpan), "0:0:5:0", "10675199.02:48:05.4775807")]
		public TimeSpan AutoDeleteOnIdle {get;set;}
        
 		public int MaxDeliveryCount { get; set; } = 10;
        
		public TimeSpan DefaultMessageTimeToLive { get; set; } = TimeSpan.MaxValue;
        
		[Range(typeof(TimeSpan), "0:0:0:20", "7:0:0:0")]
		public TimeSpan DuplicateDetectionHistoryTimeWindow  { get; set; } = TimeSpan.FromMinutes(1);

        public bool DeadLetteringOnMessageExpiration { get; set; } = false;
        
		[Range(typeof(TimeSpan), "0:0:1", "0:5:0")]
		public TimeSpan LockDuration { get; set; } = TimeSpan.FromSeconds(60);

		public bool RequiresSession { get; set; } = false;

        public bool MessageForwardingEnabled { get; set; } = false;

		public string ForwardDeadLetteredMessagesTo  {get;set;}

    }
}