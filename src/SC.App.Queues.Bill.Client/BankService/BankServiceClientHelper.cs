using System.Collections.Generic;
using System.Linq;
using SC.Services.Bank.Client;

namespace SC.App.Queues.Bill.Client.BankService
{
    public class BankServiceClientHelper
    {
        public static bool IsSuccess(ResponseOfListOfGetBankResponse response)
        {
            if (response == null)
            {
                return false;
            }

            return IsOk(response.Status);
        }

        public static bool IsSuccess(ResponseOfGetSlipVerificationResponse response)
        {
            if (response == null)
            {
                return false;
            }

            return IsOk(response.Status);
        }

        public static bool IsSuccess(ResponseOfVerifySlipResponse response)
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