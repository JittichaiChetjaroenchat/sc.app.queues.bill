using System;
using SC.App.Queues.Bill.Business.Helpers;
using SC.App.Queues.Bill.Database.Models;

namespace SC.App.Queues.Bill.Business.Mappers
{
    public class PaymentVerificationMapper
    {
        public static PaymentVerification Map(Guid paymentId, PaymentVerificationStatus paymentVerificationStatus, string extendedStatus)
        {
            var status = PaymentVerificationHelper.Get(paymentVerificationStatus);
            var isProceed = PaymentVerificationHelper.IsProceed(status);
            var canVerify = PaymentVerificationHelper.CanVerify(status);
            var isUnique = PaymentVerificationHelper.IsUnique(status);
            var isCorrectBankAccountNumber = PaymentVerificationHelper.IsCorrectBankAccountNumber(status);
            var isCorrectBankAccountName = PaymentVerificationHelper.IsCorrectBankAccountName(status);
            var isCorrectAmount = PaymentVerificationHelper.IsCorrectAmount(status);
            var remark = PaymentVerificationHelper.GetRemark(status, extendedStatus);

            return new PaymentVerification
            {
                PaymentId = paymentId,
                IsProceed = isProceed,
                CanVerify = canVerify,
                IsUnique = isUnique,
                IsCorrectBankAccountNumber = isCorrectBankAccountNumber,
                IsCorrectBankAccountName = isCorrectBankAccountName,
                IsCorrectAmount = isCorrectAmount,
                Remark = remark,
                PaymentVerificationStatusId = paymentVerificationStatus.Id
            };
        }

        public static PaymentVerification Map(PaymentVerification persistent, PaymentVerificationStatus paymentVerificationStatus, string extendedStatus)
        {
            var status = PaymentVerificationHelper.Get(paymentVerificationStatus);
            var isProceed = PaymentVerificationHelper.IsProceed(status);
            var canVerify = PaymentVerificationHelper.CanVerify(status);
            var isUnique = PaymentVerificationHelper.IsUnique(status);
            var isCorrectBankAccountNumber = PaymentVerificationHelper.IsCorrectBankAccountNumber(status);
            var isCorrectBankAccountName = PaymentVerificationHelper.IsCorrectBankAccountName(status);
            var isCorrectAmount = PaymentVerificationHelper.IsCorrectAmount(status);
            var remark = PaymentVerificationHelper.GetRemark(status, extendedStatus);

            persistent.IsProceed = isProceed;
            persistent.CanVerify = canVerify;
            persistent.IsUnique = isUnique;
            persistent.IsCorrectBankAccountNumber = isCorrectBankAccountNumber;
            persistent.IsCorrectBankAccountName = isCorrectBankAccountName;
            persistent.IsCorrectAmount = isCorrectAmount;
            persistent.IsCorrectAmount = isCorrectAmount;
            persistent.Remark = remark;
            persistent.PaymentVerificationStatusId = paymentVerificationStatus.Id;

            return persistent;
        }
    }
}