using System.Threading.Tasks;
using SC.App.Queues.Bill.Queue.Models.Messaging;

namespace SC.App.Queues.Bill.Queue.Managers.Interface
{
    public interface IQueueManager
    {
        Task ReplyChatAsync(ChatSender sender, ChatRecipient recipient, ChatContent content);
    }
}