using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using SC.App.Queues.Bill.Business.Consumers.Interface;
using SC.App.Queues.Bill.Common.Constants;
using Serilog;

namespace SC.App.Queues.Bill.Hosts
{
    public class BillHostedService : IHostedService
    {
        private readonly INotifyPaymentAcceptConsumer _notifyPaymentAcceptConsumer;
        private readonly INotifyPaymentRejectConsumer _notifyPaymentRejectConsumer;
        private readonly INotifyDeliveryAddressAcceptConsumer _notifyDeliveryAddressAcceptConsumer;
        private readonly INotifyDeliveryAddressRejectConsumer _notifyDeliveryAddressRejectConsumer;
        private readonly INotifyBillConfirmConsumer _notifyBillConfirmConsumer;
        private readonly INotifyBillBeforeCancelConsumer _notifyBillBeforeCancelConsumer;
        private readonly INotifyBillCancelConsumer _notifyBillCancelConsumer;
        private readonly INotifyBillSummaryConsumer _notifyBillSummaryConsumer;
        private readonly INotifyParcelIssueConsumer _notifyParcelIssueConsumer;
        private readonly IVerifyPaymentConsumer _verifyPaymentConsumer;
        private readonly ICancelBillConsumer _cancelBillConsumer;
        private readonly IConfiguration _configuration = null;
        private readonly IConnection _connection = null;
        private readonly IModel _channel = null;

        public BillHostedService(
            INotifyPaymentAcceptConsumer notifyPaymentAcceptConsumer,
            INotifyPaymentRejectConsumer notifyPaymentRejectConsumer,
            INotifyDeliveryAddressAcceptConsumer notifyDeliveryAddressAcceptConsumer,
            INotifyDeliveryAddressRejectConsumer notifyDeliveryAddressRejectConsumer,
            INotifyBillConfirmConsumer notifyBillConfirmConsumer,
            INotifyBillBeforeCancelConsumer notifyBillBeforeCancelConsumer,
            INotifyBillCancelConsumer notifyBillCancelConsumer,
            INotifyBillSummaryConsumer notifyBillSummaryConsumer,
            INotifyParcelIssueConsumer notifyParcelIssueConsumer,
            IVerifyPaymentConsumer verifyPaymentConsumer,
            ICancelBillConsumer cancelBillConsumer,
            IConfiguration configuration)
        {
            _notifyPaymentAcceptConsumer = notifyPaymentAcceptConsumer;
            _notifyPaymentRejectConsumer = notifyPaymentRejectConsumer;
            _notifyDeliveryAddressAcceptConsumer = notifyDeliveryAddressAcceptConsumer;
            _notifyDeliveryAddressRejectConsumer = notifyDeliveryAddressRejectConsumer;
            _notifyBillConfirmConsumer = notifyBillConfirmConsumer;
            _notifyBillBeforeCancelConsumer = notifyBillBeforeCancelConsumer;
            _notifyBillCancelConsumer = notifyBillCancelConsumer;
            _notifyBillSummaryConsumer = notifyBillSummaryConsumer;
            _notifyParcelIssueConsumer = notifyParcelIssueConsumer;
            _verifyPaymentConsumer = verifyPaymentConsumer;
            _cancelBillConsumer = cancelBillConsumer;
            _configuration = configuration;

            try
            {
                var host = _configuration.GetValue<string>(AppSettings.Queues.HostName);
                var username = _configuration.GetValue<string>(AppSettings.Queues.UserName);
                var password = _configuration.GetValue<string>(AppSettings.Queues.Password);
                var factory = new ConnectionFactory { HostName = host, UserName = username, Password = password };

                _connection = factory.CreateConnection();
                _channel = _connection.CreateModel();
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, string.Empty);
            }
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            try
            {
                _channel.ExchangeDeclare(exchange: Queue.Constants.Queue.Bill.Exchange, type: Queue.Constants.Queue.Bill.Type);
                _channel.QueueDeclare(queue: Queue.Constants.Queue.Bill.Queue, durable: false, exclusive: false, autoDelete: false, arguments: null);
                _channel.QueueBind(Queue.Constants.Queue.Bill.Queue, Queue.Constants.Queue.Bill.Exchange, Queue.Constants.Queue.Bill.NotifyPaymentAccept.RoutingKey);
                _channel.QueueBind(Queue.Constants.Queue.Bill.Queue, Queue.Constants.Queue.Bill.Exchange, Queue.Constants.Queue.Bill.NotifyPaymentReject.RoutingKey);
                _channel.QueueBind(Queue.Constants.Queue.Bill.Queue, Queue.Constants.Queue.Bill.Exchange, Queue.Constants.Queue.Bill.NotifyDeliveryAddressAccept.RoutingKey);
                _channel.QueueBind(Queue.Constants.Queue.Bill.Queue, Queue.Constants.Queue.Bill.Exchange, Queue.Constants.Queue.Bill.NotifyDeliveryAddressReject.RoutingKey);
                _channel.QueueBind(Queue.Constants.Queue.Bill.Queue, Queue.Constants.Queue.Bill.Exchange, Queue.Constants.Queue.Bill.NotifyBillConfirm.RoutingKey);
                _channel.QueueBind(Queue.Constants.Queue.Bill.Queue, Queue.Constants.Queue.Bill.Exchange, Queue.Constants.Queue.Bill.NotifyBillBeforeCancel.RoutingKey);
                _channel.QueueBind(Queue.Constants.Queue.Bill.Queue, Queue.Constants.Queue.Bill.Exchange, Queue.Constants.Queue.Bill.NotifyBillCancel.RoutingKey);
                _channel.QueueBind(Queue.Constants.Queue.Bill.Queue, Queue.Constants.Queue.Bill.Exchange, Queue.Constants.Queue.Bill.NotifyBillSummary.RoutingKey);
                _channel.QueueBind(Queue.Constants.Queue.Bill.Queue, Queue.Constants.Queue.Bill.Exchange, Queue.Constants.Queue.Bill.NotifyParcelIssue.RoutingKey);
                _channel.QueueBind(Queue.Constants.Queue.Bill.Queue, Queue.Constants.Queue.Bill.Exchange, Queue.Constants.Queue.Bill.VerifyPayment.RoutingKey);
                _channel.QueueBind(Queue.Constants.Queue.Bill.Queue, Queue.Constants.Queue.Bill.Exchange, Queue.Constants.Queue.Bill.CancelBill.RoutingKey);

                var consumer = new EventingBasicConsumer(_channel);
                consumer.Received += async (model, ea) =>
                {
                    var deliveryTag = ea.DeliveryTag;
                    var body = ea.Body.ToArray();

                    switch (ea.RoutingKey)
                    {
                        case Queue.Constants.Queue.Bill.NotifyPaymentAccept.RoutingKey:
                            await _notifyPaymentAcceptConsumer.ConsumeAsync(_channel, deliveryTag, body);
                            break;
                        case Queue.Constants.Queue.Bill.NotifyPaymentReject.RoutingKey:
                            await _notifyPaymentRejectConsumer.ConsumeAsync(_channel, deliveryTag, body);
                            break;
                        case Queue.Constants.Queue.Bill.NotifyDeliveryAddressAccept.RoutingKey:
                            await _notifyDeliveryAddressAcceptConsumer.ConsumeAsync(_channel, deliveryTag, body);
                            break;
                        case Queue.Constants.Queue.Bill.NotifyDeliveryAddressReject.RoutingKey:
                            await _notifyDeliveryAddressRejectConsumer.ConsumeAsync(_channel, deliveryTag, body);
                            break;
                        case Queue.Constants.Queue.Bill.NotifyBillConfirm.RoutingKey:
                            await _notifyBillConfirmConsumer.ConsumeAsync(_channel, deliveryTag, body);
                            break;
                        case Queue.Constants.Queue.Bill.NotifyBillBeforeCancel.RoutingKey:
                            await _notifyBillBeforeCancelConsumer.ConsumeAsync(_channel, deliveryTag, body);
                            break;
                        case Queue.Constants.Queue.Bill.NotifyBillCancel.RoutingKey:
                            await _notifyBillCancelConsumer.ConsumeAsync(_channel, deliveryTag, body);
                            break;
                        case Queue.Constants.Queue.Bill.NotifyBillSummary.RoutingKey:
                            await _notifyBillSummaryConsumer.ConsumeAsync(_channel, deliveryTag, body);
                            break;
                        case Queue.Constants.Queue.Bill.NotifyParcelIssue.RoutingKey:
                            await _notifyParcelIssueConsumer.ConsumeAsync(_channel, deliveryTag, body);
                            break;
                        case Queue.Constants.Queue.Bill.VerifyPayment.RoutingKey:
                            await _verifyPaymentConsumer.ConsumeAsync(_channel, deliveryTag, body);
                            break;
                        case Queue.Constants.Queue.Bill.CancelBill.RoutingKey:
                            await _cancelBillConsumer.ConsumeAsync(_channel, deliveryTag, body);
                            break;
                    }
                };
                _channel.BasicConsume(Queue.Constants.Queue.Bill.Queue, false, consumer);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, string.Empty);
            }

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            if (_channel.IsOpen)
            {
                _channel.Close();
            }

            if (_connection.IsOpen)
            {
                _connection.Close();
            }

            return Task.CompletedTask;
        }
    }
}