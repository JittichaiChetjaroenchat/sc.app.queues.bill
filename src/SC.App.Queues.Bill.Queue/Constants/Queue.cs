namespace SC.App.Queues.Bill.Queue.Constants
{
    public class Queue
    {
        public class Bill
        {
            public const string Queue = "bill";

            public const string Exchange = "bill";

            public const string Type = "topic";

            public class NotifyPaymentAccept
            {
                public const string RoutingKey = "bill.notify_payment_accept";
            }

            public class NotifyPaymentReject
            {
                public const string RoutingKey = "bill.notify_payment_reject";
            }

            public class NotifyDeliveryAddressAccept
            {
                public const string RoutingKey = "bill.notify_delivery_address_accept";
            }

            public class NotifyDeliveryAddressReject
            {
                public const string RoutingKey = "bill.notify_delivery_address_reject";
            }

            public class NotifyBillConfirm
            {
                public const string RoutingKey = "bill.notify_bill_confirm";
            }

            public class NotifyBillBeforeCancel
            {
                public const string RoutingKey = "bill.notify_bill_before_cancel";
            }

            public class NotifyBillCancel
            {
                public const string RoutingKey = "bill.notify_bill_cancel";
            }

            public class NotifyBillSummary
            {
                public const string RoutingKey = "bill.notify_bill_summary";
            }

            public class NotifyParcelIssue
            {
                public const string RoutingKey = "bill.notify_parcel_issue";
            }

            public class VerifyPayment
            {
                public const string RoutingKey = "bill.verify_payment";
            }

            public class CancelBill
            {
                public const string RoutingKey = "bill.cancel_bill";
            }
        }

        public class Messaging
        {
            public const string Queue = "messaging";

            public const string Exchange = "messaging";

            public const string Type = "topic";

            public class ReplyChat
            {
                public const string RoutingKey = "messaging.reply_chat";
            }
        }
    }
}