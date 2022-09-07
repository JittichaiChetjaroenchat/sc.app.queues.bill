using System;
using SC.App.Queues.Bill.Business.Enums;
using SC.App.Queues.Bill.Lib.Extensions;

namespace SC.App.Queues.Bill.Business.Helpers
{
    public class BillHelper
    {
        private const string DEFAULT_LANGUAGE = "th";

        public static string GetLink(string baseUrl, string key, string language)
        {
            var path = language.IsEmpty() || language.Equals(DEFAULT_LANGUAGE, StringComparison.OrdinalIgnoreCase) ? string.Empty : $"{language}/";
            var link = $"{baseUrl}/{path}bill/{key}";

            return link;
        }

        public static bool IsInProcess(Database.Models.Bill bill)
        {
            var isNotified = IsNotified(bill);
            var isConfirmed = IsConfirmed(bill);

            return isNotified || isConfirmed;
        }

        public static bool IsEndState(Database.Models.Bill bill)
        {
            var isDone = IsDone(bill);
            var isCancelled = IsCancelled(bill);
            var isArchieved = IsArchieved(bill);
            var isDeleted = IsDeleted(bill);

            return isDone || isCancelled || isArchieved || isDeleted;
        }

        public static bool IsPending(Database.Models.Bill bill)
        {
            var status = EnumBillStatus.Pending.GetDescription();

            return bill.BillStatus.Code == status;
        }

        public static bool IsNotified(Database.Models.Bill bill)
        {
            var status = EnumBillStatus.Notified.GetDescription();

            return bill.BillStatus.Code == status;
        }

        public static bool IsConfirmed(Database.Models.Bill bill)
        {
            var status = EnumBillStatus.Confirmed.GetDescription();

            return bill.BillStatus.Code == status;
        }

        public static bool IsDone(Database.Models.Bill bill)
        {
            var status = EnumBillStatus.Done.GetDescription();

            return bill.BillStatus.Code == status;
        }

        public static bool IsCancelled(Database.Models.Bill bill)
        {
            var status = EnumBillStatus.Cancelled.GetDescription();

            return bill.BillStatus.Code == status;
        }

        public static bool IsArchieved(Database.Models.Bill bill)
        {
            var status = EnumBillStatus.Archived.GetDescription();

            return bill.BillStatus.Code == status;
        }

        public static bool IsDeleted(Database.Models.Bill bill)
        {
            var status = EnumBillStatus.Deleted.GetDescription();

            return bill.BillStatus.Code == status;
        }
    }
}