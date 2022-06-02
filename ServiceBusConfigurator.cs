using Azure.Messaging.ServiceBus;
using Azure.Messaging.ServiceBus.Administration;

namespace SbConfiguration
{
    public class ServiceBusConfigurator
    {
        private readonly ServiceBusConfiguration _serviceBusConfig;
        private readonly ServiceBusAdministrationClient _adminClient;

        public ServiceBusConfigurator(ServiceBusAdministrationClient adminClient, ServiceBusConfiguration serviceBusConfig)
        {
            _serviceBusConfig = serviceBusConfig;
            _adminClient = adminClient;
        }

        public async Task AssureAllQueuesAndTopics()
        {
            await AssureAllQueues();
            await AssureAllTopicsAndSubscriptions();
        }

        internal async Task AssureAllTopicsAndSubscriptions()
        {
            foreach (var topic in _serviceBusConfig.Topics)
            {
                if (!await _adminClient.TopicExistsAsync(topic.Name))
                {
                    await CreateTopicWithProperties(topic);
                }

                await CreateSubscriptionsForTopic(topic);
            }
        }

        internal async Task CreateTopicWithProperties(Topic topic)
        {
            var createTopicOptions = new CreateTopicOptions(topic.Name)
            {
                DefaultMessageTimeToLive = TimeSpan.FromDays(topic.DaysUntilAutoDelete),
                AutoDeleteOnIdle = TimeSpan.FromDays(topic.DaysUntilAutoDelete),
                MaxSizeInMegabytes = topic.MaxSizeInMegabytes
            };
            try
            {
                await _adminClient.CreateTopicAsync(createTopicOptions);
            }
            catch (ServiceBusException ex) when (ex.Reason == ServiceBusFailureReason.MessagingEntityAlreadyExists)
            {
                //intentionally eat this exception which is almost certainly due to 
                //a race condition where another process has created this topic first.
            }
        }

        internal async Task CreateSubscriptionsForTopic(Topic topic)
        {
            foreach (var subscription in topic.Subscriptions)
            {
                if (!await _adminClient.SubscriptionExistsAsync(topic.Name, subscription.Name))
                {
                    var createRuleOptions = new CreateRuleOptions()
                    {
                        Name = subscription.DefaultRule.Name,
                        Filter = new SqlRuleFilter(subscription.DefaultRule.Filter)
                    };

                    var subscriptionOptions = new CreateSubscriptionOptions(topic.Name, subscription.Name)
                    {
                        DefaultMessageTimeToLive = TimeSpan.FromDays(subscription.DaysUntilAutoDelete),
                        LockDuration = TimeSpan.FromSeconds(subscription.MessageLockDurationInSeconds),
                        MaxDeliveryCount = subscription.MaxDeliveryCount,
                        AutoDeleteOnIdle = TimeSpan.FromDays(subscription.DaysUntilAutoDelete),
                        DeadLetteringOnMessageExpiration = subscription.DeadLetteringEnabled
                    };
                    try
                    {
                        await _adminClient.CreateSubscriptionAsync(subscriptionOptions, createRuleOptions);
                    }
                    catch (ServiceBusException ex) when (ex.Reason == ServiceBusFailureReason.MessagingEntityAlreadyExists)
                    {
                        //intentionally eat this exception which is almost certainly due to 
                        //a race condition where another process has created this topic first.
                    }

                }
            }
        }

        internal async Task AssureAllQueues()
        {
            foreach (var queue in _serviceBusConfig.Queues)
            {
                if (!await _adminClient.QueueExistsAsync(queue.Name))
                {
                    await CreateQueueWithOptions(queue);
                }
            }
        }

        internal async Task CreateQueueWithOptions(Queue queue)
        {
            var createQueueOptions = new CreateQueueOptions(queue.Name)
            {
                DefaultMessageTimeToLive = TimeSpan.FromDays(queue.DaysUntilAutoDelete),
                LockDuration = TimeSpan.FromSeconds(queue.MessageLockDurationInSeconds),
                MaxDeliveryCount = queue.MaxDeliveryCount,
                AutoDeleteOnIdle = TimeSpan.FromDays(queue.DaysUntilAutoDelete),
                DeadLetteringOnMessageExpiration = queue.DeadLetteringEnabled,
                MaxSizeInMegabytes = queue.MaxSizeInMegabytes
            };
            try
            {
                await _adminClient.CreateQueueAsync(createQueueOptions);
            }
            catch (ServiceBusException ex) when (ex.Reason == ServiceBusFailureReason.MessagingEntityAlreadyExists)
            {
                //intentionally eat this exception which is almost certainly due to 
                //a race condition where another process has reated this queue first.
            }
        }
    }
}