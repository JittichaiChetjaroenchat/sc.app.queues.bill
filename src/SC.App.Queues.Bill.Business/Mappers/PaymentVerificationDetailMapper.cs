using System;
using SC.App.Queues.Bill.Database.Models;
using SC.Services.Bank.Client;

namespace SC.App.Queues.Bill.Business.Mappers
{
    public class PaymentVerificationDetailMapper
    {
        public static PaymentVerificationDetail Map(Guid paymentVerificationId, GetSlipVerificationDetail detail)
        {
            return new PaymentVerificationDetail
            {
                PaymentVerificationId = paymentVerificationId,
                SourceBankCode = detail.Source.Bank.Code,
                SourceBankAccountType = detail.Source.Type,
                SourceBankAccountNumber = detail.Source.Number,
                SourceBankAccountName = detail.Source.Name,
                SourceBankAccountDisplayName = detail.Source.Display_name,
                DestinationBankCode = detail.Destination.Bank.Code,
                DestinationBankAccountType = detail.Destination.Type,
                DestinationBankAccountNumber = detail.Destination.Number,
                DestinationBankAccountName = detail.Destination.Name,
                DestinationBankAccountDisplayName = detail.Destination.Display_name,
                Amount = detail.Amount,
                TransactionRefNo = detail.Transaction_ref_no,
                TransactionDate = detail.Transaction_date.Date
            };
        }
    }
}