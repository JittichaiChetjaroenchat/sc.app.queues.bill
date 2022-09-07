using System.Collections.Generic;
using System.Linq;
using SC.Services.Messaging.Client;

namespace SC.App.Queues.Bill.Client.MessagingService
{
    public class MessagingServiceClientHelper
    {
        public static bool IsSuccess(ResponseOfSendMessageResponse response)
        {
            if (response == null)
            {
                return false;
            }

            return IsOk(response.Status);
        }

        public static ResponseError GetError(ICollection<ResponseError> errors)
        {
            return errors.FirstOrDefault();
        }

        private static bool IsOk(EnumResponseStatus status)
        {
            return status == EnumResponseStatus.OK;
        }
    }
}