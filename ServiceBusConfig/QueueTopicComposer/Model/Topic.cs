namespace QueueTopicComposer.Model
{
    public class Topic : QueueSettings
    {
        public Subscription[] Subscriptions { get; set; } = new Subscription[0];
    }
}