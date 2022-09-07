using System;
using System.Threading.Tasks;
using SC.App.Queues.Bill.Queue.Managers.Interface;
using SC.App.Queues.Bill.Queue.Models.Messaging;
using SC.App.Queues.Bill.Queue.Providers.Interface;
using Serilog;

namespace SC.App.Queues.Bill.Queue.Managers
{
    public class QueueManager : IQueueManager
    {
        private readonly IQueueProvider _queueProvider;

        public QueueManager(
            IQueueProvider queueProvider)
        {
            _queueProvider = queueProvider;
        }

        public async Task ReplyChatAsync(ChatSender sender, ChatRecipient recipient, ChatContent content)
        {
            try
            {
                // Publish
                var payload = new Chat
                {
                    Sender = sender,
                    Recipient = recipient,
                    Content = content
                };
                _queueProvider.Publish(Constants.Queue.Messaging.Queue, Constants.Queue.Messaging.Exchange, Constants.Queue.Messaging.ReplyChat.RoutingKey, payload);
            }
            catch (Exception ex)
            {
                Log.Error(ex, string.Empty);
            }

            await Task.CompletedTask;
        }
    }
}