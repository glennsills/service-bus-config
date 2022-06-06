namespace QueueTopicComposer.Model
{
    public class Topic : Queue
    {
        public Subscription[] Subscriptions { get; set; } = new Subscription[0];
    }
}