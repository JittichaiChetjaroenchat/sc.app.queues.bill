using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SC.App.Queues.Bill.Business.Enums;
using SC.App.Queues.Bill.Business.Order.Helpers;
using SC.App.Queues.Bill.Lib.Extensions;

namespace SC.App.Queues.Bill.Business.Helpers
{
    public class ResponseMessageHelper
    {
        private const string NUMBER_FORMAT = "{0:#,##0.##}";
        private const string DATETIME_FORMAT = "yyyy-MM-dd HH:mm";
        private const string PAYMENT_AMOUNT_TAG = "{payment_amount}";
        private const string BILL_NO_TAG = "{bill_no}";
        private const string BILL_LINK_TAG = "{bill_link}";
        private const string ORDERS_TAG = "{orders}";
        private const string BILL_CANCEL_TIME_TAG = "{bill_cancel_time}";
        private const string PARCEL_NO_TAG = "{parcel_no}";
        private const string RECIPIENT_NAME_TAG = "{recipient_name}";
        private const string RECIPIENT_PHONE_NO_TAG = "{recipient_phone_no}";
        private const string DELIVERY_ADDRESS_TAG = "{delivery_address}";

        public static string GetResponseMessage(EnumResponseMessageType responseMessageType, Setting.Database.Models.ResponseMessage responseMessage)
        {
            switch (responseMessageType)
            {
                case EnumResponseMessageType.NotifyPaymentAccept:
                    return responseMessage.PaymentAcceptMessage;
                case EnumResponseMessageType.NotifyPaymentReject:
                    return responseMessage.PaymentRejectMessage;
                case EnumResponseMessageType.NotifyDeliveryAddressAccept:
                    return responseMessage.DeliveryAddressAcceptMessage;
                case EnumResponseMessageType.NotifyDeliveryAddressReject:
                    return responseMessage.DeliveryAddressRejectMessage;
                case EnumResponseMessageType.NotifyBillConfirm:
                    return responseMessage.BillConfirmMessage;
                case EnumResponseMessageType.NotifyBillBeforeCancel:
                    return responseMessage.BillNotifyBeforeCancelMessage;
                case EnumResponseMessageType.NotifyBillCancel:
                    return responseMessage.BillCancelMessage;
                case EnumResponseMessageType.NotifyBillSummary:
                    return responseMessage.BillSummaryMessage;
                case EnumResponseMessageType.NotifyParcelIssue:
                    return responseMessage.ParcelIssueMessage;
            }

            return null;
        }

        public static bool GetResponseMessageEnabled(EnumResponseMessageType responseMessageType, Setting.Database.Models.ResponseMessage responseMessage)
        {
            switch (responseMessageType)
            {
                case EnumResponseMessageType.NotifyPaymentAccept:
                    return responseMessage.PaymentAcceptMessageEnabled;
                case EnumResponseMessageType.NotifyPaymentReject:
                    return responseMessage.PaymentRejectMessageEnabled;
                case EnumResponseMessageType.NotifyBillConfirm:
                    return responseMessage.BillConfirmMessageEnabled;
                case EnumResponseMessageType.NotifyBillBeforeCancel:
                    return responseMessage.BillNotifyBeforeCancelMessageEnabled;
                case EnumResponseMessageType.NotifyBillCancel:
                    return responseMessage.BillCancelMessageEnabled;
                case EnumResponseMessageType.NotifyBillSummary:
                    return responseMessage.BillSummaryMessageEnabled;
                case EnumResponseMessageType.NotifyParcelIssue:
                    return responseMessage.ParcelIssueMessageEnabled;
            }

            return false;
        }

        public static string NotifyAcceptPayment(string template, Database.Models.Bill bill, Database.Models.Payment payment)
        {
            var billNoTag = bill.BillNo;
            var paymentAmountTag = GetNumberFormat(payment.Amount);
            var message = template
                .Replace(BILL_NO_TAG, billNoTag)
                .Replace(PAYMENT_AMOUNT_TAG, paymentAmountTag);
            var timestamp = GetTimeStamp();

            return $"{message}\n\n{timestamp}";
        }

        public static string NotifyRejectPayment(string template, Database.Models.Bill bill, Database.Models.Payment payment)
        {
            var billNoTag = bill.BillNo;
            var paymentAmountTag = GetNumberFormat(payment.Amount);
            var message = template
                .Replace(BILL_NO_TAG, billNoTag)
                .Replace(PAYMENT_AMOUNT_TAG, paymentAmountTag);
            var timestamp = GetTimeStamp();

            return $"{message}\n\n{timestamp}";
        }

        public static string NotifyAcceptDeliveryAddress(string template, Database.Models.Bill bill, Database.Models.BillRecipient recipient, Database.Models.BillRecipientContact recipientContact, Area.Database.Models.Area area)
        {
            var billNoTag = bill.BillNo;
            var recipientNameTag = recipient.Name;
            var recipientPhoneNoTag = GetRecipientPhoneNo(recipientContact);
            var deliveryAddressTag = GetDeliveryAddress(recipientContact, area);
            var message = template
                .Replace(BILL_NO_TAG, billNoTag)
                .Replace(RECIPIENT_NAME_TAG, recipientNameTag)
                .Replace(RECIPIENT_PHONE_NO_TAG, recipientPhoneNoTag)
                .Replace(DELIVERY_ADDRESS_TAG, deliveryAddressTag);
            var timestamp = GetTimeStamp();

            return $"{message}\n\n{timestamp}";
        }

        public static string NotifyRejectDeliveryAddress(string template, Database.Models.Bill bill)
        {
            var billNoTag = bill.BillNo;
            var message = template
                .Replace(BILL_NO_TAG, billNoTag);
            var timestamp = GetTimeStamp();

            return $"{message}\n\n{timestamp}";
        }

        public static string NotifyConfirmBill(string template, Database.Models.Bill bill, List<Order.Database.Models.Order> orders, List<Inventory.Database.Models.Product> products, Database.Models.BillRecipientContact recipientContact, Area.Database.Models.Area area)
        {
            var billNoTag = bill.BillNo;
            var ordersTag = GetOrders(orders, products);
            var deliveryAddressTag = GetDeliveryAddress(recipientContact, area);
            var summary = GetSummary(bill, orders);
            var message = template
                .Replace(BILL_NO_TAG, billNoTag)
                .Replace(ORDERS_TAG, $"{ordersTag}\n{summary}")
                .Replace(DELIVERY_ADDRESS_TAG, deliveryAddressTag);
            var timestamp = GetTimeStamp();

            return $"{message}\n\n{timestamp}";
        }

        public static string NotifyBeforeCancelBill(string template, Database.Models.Bill bill, DateTime? cancelTime)
        {
            var billNoTag = bill.BillNo;
            var billCancelTimeTag = GetBillCancelTime(cancelTime);
            var message = template
                .Replace(BILL_NO_TAG, billNoTag)
                .Replace(BILL_CANCEL_TIME_TAG, billCancelTimeTag);
            var timestamp = GetTimeStamp();

            return $"{message}\n\n{timestamp}";
        }

        public static string NotifyCancelBill(string template, Database.Models.Bill bill)
        {
            var billNoTag = bill.BillNo;
            var message = template
                .Replace(BILL_NO_TAG, billNoTag);
            var timestamp = GetTimeStamp();

            return $"{message}\n\n{timestamp}";
        }

        public static string NotifySummaryBill(string template, string buyerBaseUrl, Database.Models.Bill bill, List<Order.Database.Models.Order> orders, List<Inventory.Database.Models.Product> products, Setting.Database.Models.Preferences preferences)
        {
            var billNoTag = bill.BillNo;
            var ordersTag = GetOrders(orders, products);
            var summary = GetSummary(bill, orders);
            var billLinkTag = GetBillLink(buyerBaseUrl, bill, preferences);
            var message = template
                .Replace(BILL_NO_TAG, billNoTag)
                .Replace(ORDERS_TAG, $"{ordersTag}\n{summary}")
                .Replace(BILL_LINK_TAG, billLinkTag);
            
            var timestamp = GetTimeStamp();

            return $"{message}\n\n{timestamp}";
        }

        public static string NotifyIssueParcel(string template, Courier.Database.Models.Order courierOrder, Database.Models.BillRecipient recipient, Database.Models.BillRecipientContact recipientContact, Area.Database.Models.Area area)
        {
            var parcelNoTag = courierOrder.OrderFeedback.Ref1;
            var recipientNameTag = recipient.Name;
            var recipientPhoneNoTag = GetRecipientPhoneNo(recipientContact);
            var deliveryAddressTag = GetDeliveryAddress(recipientContact, area);
            var message = template
                .Replace(PARCEL_NO_TAG, parcelNoTag)
                .Replace(RECIPIENT_NAME_TAG, recipientNameTag)
                .Replace(RECIPIENT_PHONE_NO_TAG, recipientPhoneNoTag)
                .Replace(DELIVERY_ADDRESS_TAG, deliveryAddressTag);
            var timestamp = GetTimeStamp();

            return $"{message}\n\n{timestamp}";
        }

        public static string GetPaymentEvidence(string baseUrl, Database.Models.Payment payment)
        {
            var url = $"{baseUrl}/document/api/documents/raw?document_type=payment&reference_id={payment.Id}";

            return url;
        }

        private static string GetBillLink(string buyerBaseUrl, Database.Models.Bill bill, Setting.Database.Models.Preferences preferences)
        {
            if (buyerBaseUrl.IsEmpty() || bill == null || preferences == null)
            {
                return null;
            }

            return BillHelper.GetLink(buyerBaseUrl, bill.Key, preferences.Language);
        }

        private static string GetBillCancelTime(DateTime? cancelTime)
        {
            if (cancelTime.HasValue)
            {
                return GetDateTimeFormat(cancelTime.Value);
            }

            return string.Empty;
        }

        private static string GetRecipientPhoneNo(Database.Models.BillRecipientContact recipientContact)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(recipientContact.PrimaryPhone);

            if (!recipientContact.SecondaryPhone.IsEmpty())
            {
                sb.AppendFormat("/{0}", recipientContact.SecondaryPhone);
            }

            return $"{sb}";
        }

        private static string GetDeliveryAddress(Database.Models.BillRecipientContact recipientContact, Area.Database.Models.Area area)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(recipientContact.Address);

            if (area != null)
            {
                sb.Append($" {area.SubDistrict} {area.District} {area.Province} {area.PostalCode}");
            }

            return sb.ToString();
        }

        private static string GetOrders(List<Order.Database.Models.Order> orders, List<Inventory.Database.Models.Product> products)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var order in orders)
            {
                var product = products
                    .FirstOrDefault(x => x.Id == order.ProductId);
                sb.Append(GetOrder(order, product));
            }

            return sb.ToString();
        }

        private static string GetOrder(Order.Database.Models.Order order, Inventory.Database.Models.Product product)
        {
            var name = GetProduct(product);
            var code = order.Code;
            var amount = order.Amount;
            var price = GetNumberFormat(OrderHelper.GetPrice(order));

            return $"{name} ({code}) จำนวน {amount} ชิ้น = {price} บาท\n";
        }

        private static string GetProduct(Inventory.Database.Models.Product product)
        {
            if (!product.Color.IsEmpty() && !product.Size.IsEmpty())
            {
                return $"{product.Name} ({product.Color}/{product.Size})";
            }
            else if (!product.Color.IsEmpty() && product.Size.IsEmpty())
            {
                return $"{product.Name} ({product.Color})";
            }
            else if (product.Color.IsEmpty() && !product.Size.IsEmpty())
            {
                return $"{product.Name} ({product.Size})";
            }

            return product.Name;
        }

        private static string GetSummary(Database.Models.Bill bill, List<Order.Database.Models.Order> orders)
        {
            var amount = OrderHelper.GetAmount(orders);
            var goodsCost = OrderHelper.GetPrice(orders);
            var shippingCost = ShippingHelper.CalculateCost(orders, bill.BillShipping);
            var beforeDiscount = goodsCost + shippingCost;
            var discount = DiscountHelper.Calculate(beforeDiscount, bill.BillDiscount);
            var afterDiscount = beforeDiscount - discount;
            var cod = CodHelper.Calculate(afterDiscount, bill.BillPayment);
            var afterCod = afterDiscount + cod;
            var vat = VatHelper.Calculate(afterCod, bill.BillPayment);
            var afterVat = afterCod + vat;
            var total = afterVat;

            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("จำนวน  {0} ชิ้น\n", amount);
            sb.AppendFormat("ค่าสินค้า  {0} บาท\n", GetNumberFormat(goodsCost));
            sb.AppendFormat("ค่าส่ง  {0} บาท\n", GetNumberFormat(shippingCost));

            if (discount > 0)
            {
                sb.AppendFormat("ส่วนลด  {0} บาท\n", GetNumberFormat(discount));
            }

            if (cod > 0)
            {
                sb.AppendFormat("ชาร์จเก็บเงินปลายทาง (COD)  {0} บาท\n", GetNumberFormat(cod));
            }

            if (vat > 0)
            {
                sb.AppendFormat("ภาษีมูลค่าเพิ่ม (VAT)  {0} บาท\n", GetNumberFormat(vat));
            }

            sb.AppendFormat("รวม  {0} บาท", GetNumberFormat(total));

            return sb.ToString();
        }

        private static string GetTimeStamp()
        {
            return DateTime.Now.ToString(DATETIME_FORMAT);
        }

        private static string GetNumberFormat(decimal value)
        {
            return String.Format(NUMBER_FORMAT, value);
        }

        private static string GetDateTimeFormat(DateTime value)
        {
            return value.ToString(DATETIME_FORMAT);
        }
    }
}