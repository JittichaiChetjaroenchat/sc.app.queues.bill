using System.Threading.Tasks;
using SC.Services.Messaging.Client;

namespace SC.App.Queues.Bill.Client.MessagingService
{
    public interface IMessagingServiceManager
    {
        Task<ResponseOfSendMessageResponse> SendAsync(SendMessage payload);
    }
}