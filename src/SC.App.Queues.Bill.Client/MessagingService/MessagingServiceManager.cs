using System.Threading.Tasks;
using SC.Services.Messaging.Client;

namespace SC.App.Queues.Bill.Client.MessagingService
{
    public class MessagingServiceManager : IMessagingServiceManager
    {
        private readonly IMessagingServiceClient _messagingServiceClient;

        public MessagingServiceManager(IMessagingServiceClient messagingServiceClient)
        {
            _messagingServiceClient = messagingServiceClient;
        }

        public async Task<ResponseOfSendMessageResponse> SendAsync(SendMessage payload)
        {
            try
            {
                var response = await _messagingServiceClient.Messages_SendAsync(payload);

                return await Task.FromResult(response);
            }
            catch
            {
                throw;
            }
        }
    }
}