using QueueTopicComposer.Model;

namespace QueueTopicComposer
{
    public class ServiceBusConfiguration
    {
        public string ServiceBusConnection { get; set; } = string.Empty;
        public QueueSettings[] Queues { get; set; } = new QueueSettings[0];
        public Topic[] Topics { get; set; } = new Topic[0];
    }
}