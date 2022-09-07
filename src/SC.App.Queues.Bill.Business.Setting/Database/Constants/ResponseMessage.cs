namespace SC.App.Queues.Bill.Business.Setting.Database.Constants
{
    public class ResponseMessage
    {
        public const string TableName = "response_messages";

        public static class Column
        {
            public const string Id = "id";

            public const string ChannelId = "channel_id";

            public const string IsComplete = "is_complete";

            public const string StatusId = "status_id";

            public const string CreatedBy = "created_by";

            public const string CreatedOn = "created_on";

            public const string UpdatedBy = "updated_by";

            public const string UpdatedOn = "updated_on";

            public const string MessagingMethodId = "messaging_method_id";

            public const string MessagingRateId = "messaging_rate_id";

            public const string MessagingDelay = "messaging_delay";

            public const string Enabled = "enabled";

            public const string VoiceNotificationEnabled = "voice_notification_enabled";

            public const string VoiceNotificationSuffix = "voice_notification_suffix";

            #region Request offer's link

            public const string RequestOfferLinkCode = "request_offer_link_code";

            public const string RequestOfferLinkEnabled = "request_offer_link_enabled";

            #endregion

            #region Order confirm

            public const string OrderConfirmReactionEnabled = "order_confirm_reaction_enabled";

            public const string OrderConfirmImageEnabled = "order_confirm_image_enabled";

            public const string OrderConfirmFirstMessage = "order_confirm_first_message";

            public const string OrderConfirmNextMessage = "order_confirm_next_message";

            public const string OrderConfirmMessageEnabled = "order_confirm_message_enabled";

            #endregion

            #region Order cancel

            public const string OrderCancelImageEnabled = "order_cancel_image_enabled";

            public const string OrderCancelMessage = "order_cancel_message";

            public const string OrderCancelMessageEnabled = "order_cancel_message_enabled";

            #endregion

            #region Order out of stock

            public const string OrderOutOfStockMessage = "order_out_of_stock_message";

            public const string OrderOutOfStockMessageEnabled = "order_out_of_stock_message_enabled";

            #endregion

            #region Order exceed limit

            public const string OrderExceedLimitMessage = "order_exceed_limit_message";

            public const string OrderExceedLimitMessageEnabled = "order_exceed_limit_message_enabled";

            #endregion

            #region Booking confirm

            public const string BookingConfirmMessage = "booking_confirm_message";

            public const string BookingConfirmMessageEnabled = "booking_confirm_message_enabled";

            #endregion

            #region Booking cancel

            public const string BookingCancelMessage = "booking_cancel_message";

            public const string BookingCancelMessageEnabled = "booking_cancel_message_enabled";

            #endregion

            #region Payment receive

            public const string PaymentReceiveMessage = "payment_receive_message";

            public const string PaymentReceiveMessageEnabled = "payment_receive_message_enabled";

            #endregion

            #region Payment accept

            public const string PaymentAcceptMessage = "payment_accept_message";

            public const string PaymentAcceptMessageEnabled = "payment_accept_message_enabled";

            #endregion

            #region Payment reject

            public const string PaymentRejectMessage = "payment_reject_message";

            public const string PaymentRejectMessageEnabled = "payment_reject_message_enabled";

            #endregion

            #region Delivery address receive

            public const string DeliveryAddressReceiveMessage = "delivery_address_receive_message";

            public const string DeliveryAddressReceiveMessageEnabled = "delivery_address_receive_message_enabled";

            #endregion

            #region Delivery address accept

            public const string DeliveryAddressAcceptMessage = "delivery_address_accept_message";

            public const string DeliveryAddressAcceptMessageEnabled = "delivery_address_accept_message_enabled";

            #endregion

            #region Delivery address reject

            public const string DeliveryAddressRejectMessage = "delivery_address_reject_message";

            public const string DeliveryAddressRejectMessageEnabled = "delivery_address_reject_message_enabled";

            #endregion

            #region Bill confirm

            public const string BillConfirmMessage = "bill_confirm_message";

            public const string BillConfirmMessageEnabled = "bill_confirm_message_enabled";

            #endregion

            #region Bill's notify before cancel

            public const string BillNotifyBeforeCancelMessage = "bill_notify_before_cancel_message";

            public const string BillNotifyBeforeCancelMessageEnabled = "bill_notify_before_cancel_message_enabled";

            #endregion

            #region Bill cancel

            public const string BillCancelMessage = "bill_cancel_message";

            public const string BillCancelMessageEnabled = "bill_cancel_message_enabled";

            #endregion

            #region Bill summary

            public const string BillSummaryMessage = "bill_summary_message";

            public const string BillSummaryMessageEnabled = "bill_summary_message_enabled";

            #endregion

            #region Parcel issue

            public const string ParcelIssueMessage = "parcel_issue_message";

            public const string ParcelIssueMessageEnabled = "parcel_issue_message_enabled";

            #endregion

            #region Parcel status

            public const string ParcelNotifyStatusEnabled = "parcel_notify_status_enabled";

            #endregion
        }
    }
}