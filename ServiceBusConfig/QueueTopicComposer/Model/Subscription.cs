namespace QueueTopicComposer.Model
{
    public class Subscription : BaseQueueProperties
    {
        public Rule DefaultRule { get; set; } = new Rule();
    }
}