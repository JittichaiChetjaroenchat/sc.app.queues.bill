using System;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SC.App.Queues.Bill.Business.Consumers;
using SC.App.Queues.Bill.Business.Consumers.Interface;
using SC.App.Queues.Bill.Business.Managers;
using SC.App.Queues.Bill.Business.Managers.Interface;
using SC.App.Queues.Bill.Business.Repositories;
using SC.App.Queues.Bill.Business.Repositories.Interface;
using SC.App.Queues.Bill.Client.BankService;
using SC.App.Queues.Bill.Client.MessagingService;
using SC.App.Queues.Bill.Common.Constants;
using SC.App.Queues.Bill.Hosts;
using SC.App.Queues.Bill.Queue.Managers;
using SC.App.Queues.Bill.Queue.Managers.Interface;
using SC.App.Queues.Bill.Queue.Providers;
using SC.App.Queues.Bill.Queue.Providers.Interface;
using SC.Services.Bank.Client;
using SC.Services.Messaging.Client;

namespace SC.App.Queues.Bill.Configurations.Extensions
{
    public static class DependencyExtension
    {
        public static void AddDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddManagers();
            services.AddRepositories();
            services.AddQueues();
            services.AddHandlers();
            services.AddClients(configuration);
        }

        private static void AddManagers(this IServiceCollection services)
        {
            // Bill
            services.AddScoped<INotifyPaymentAcceptConsumer, NotifyPaymentAcceptConsumer>();
            services.AddScoped<INotifyPaymentRejectConsumer, NotifyPaymentRejectConsumer>();
            services.AddScoped<INotifyDeliveryAddressAcceptConsumer, NotifyDeliveryAddressAcceptConsumer>();
            services.AddScoped<INotifyDeliveryAddressRejectConsumer, NotifyDeliveryAddressRejectConsumer>();
            services.AddScoped<INotifyBillConfirmConsumer, NotifyBillConfirmConsumer>();
            services.AddScoped<INotifyBillCancelConsumer, NotifyBillCancelConsumer>();
            services.AddScoped<INotifyBillBeforeCancelConsumer, NotifyBillBeforeCancelConsumer>();
            services.AddScoped<INotifyBillSummaryConsumer, NotifyBillSummaryConsumer>();
            services.AddScoped<INotifyParcelIssueConsumer, NotifyParcelIssueConsumer>();
            services.AddScoped<IVerifyPaymentConsumer, VerifyPaymentConsumer>();
            services.AddScoped<ICancelBillConsumer, CancelBillConsumer>();

            services.AddScoped<IBillQueueManager, BillQueueManager>();

            services.AddScoped<IBillProcessManager, BillProcessManager>();
            services.AddScoped<IParcelProcessManager, ParcelProcessManager>();
            services.AddScoped<IPaymentProcessManager, PaymentProcessManager>();
            services.AddScoped<IPaymentVerificationProcessManager, PaymentVerificationProcessManager>();

            // Credit
            services.AddScoped<Business.Credit.Managers.Interface.ICreditManager, Business.Credit.Managers.CreditManager>();

            // Customer
            services.AddScoped<Business.Customer.Managers.Interface.ICustomerManager, Business.Customer.Managers.CustomerManager>();

            // Inventory
            services.AddScoped<Business.Inventory.Managers.Interface.IProductManager, Business.Inventory.Managers.ProductManager>();

            // Order
            services.AddScoped<Business.Order.Managers.Interface.IOrderManager, Business.Order.Managers.OrderManager>();

            // Streaming
            services.AddScoped<Business.Streaming.Managers.Interface.IBookingUnlockManager, Business.Streaming.Managers.BookingUnlockManager>();
        }

        private static void AddRepositories(this IServiceCollection services)
        {
            // Area
            services.AddScoped<Business.Area.Repositories.Interface.IAreaRepository, Business.Area.Repositories.AreaRepository>();

            // Bill
            services.AddScoped<IBillRepository, BillRepository>();
            services.AddScoped<IBillNotificationRepository, BillNotificationRepository>();
            services.AddScoped<IBillStatusRepository, BillStatusRepository>();
            services.AddScoped<IParcelRepository, ParcelRepository>();
            services.AddScoped<IPaymentRepository, PaymentRepository>();
            services.AddScoped<IPaymentStatusRepository, PaymentStatusRepository>();
            services.AddScoped<IPaymentVerificationRepository, PaymentVerificationRepository>();
            services.AddScoped<IPaymentVerificationDetailRepository, PaymentVerificationDetailRepository>();
            services.AddScoped<IPaymentVerificationStatusRepository, PaymentVerificationStatusRepository>();

            // Courier
            services.AddScoped<Business.Courier.Repositories.Interface.IOrderRepository, Business.Courier.Repositories.OrderRepository>();

            // Credit
            services.AddScoped<Business.Credit.Repositories.Interface.ICreditRepository, Business.Credit.Repositories.CreditRepository>();
            services.AddScoped<Business.Credit.Repositories.Interface.ICreditTransactionRepository, Business.Credit.Repositories.CreditTransactionRepository>();
            services.AddScoped<Business.Credit.Repositories.Interface.ICreditExpenseTypeRepository, Business.Credit.Repositories.CreditExpenseTypeRepository>();

            // Customer
            services.AddScoped<Business.Customer.Repositories.Interface.ICustomerRepository, Business.Customer.Repositories.CustomerRepository>();

            // Inventory
            services.AddScoped<Business.Inventory.Repositories.Interface.IProductRepository, Business.Inventory.Repositories.ProductRepository>();

            // Order
            services.AddScoped<Business.Order.Repositories.Interface.IOrderRepository, Business.Order.Repositories.OrderRepository>();
            services.AddScoped<Business.Order.Repositories.Interface.IOrderStatusRepository, Business.Order.Repositories.OrderStatusRepository>();

            // Setting
            services.AddScoped<Business.Setting.Repositories.Interface.IBillingRepository, Business.Setting.Repositories.BillingRepository>();
            services.AddScoped<Business.Setting.Repositories.Interface.IPaymentRepository, Business.Setting.Repositories.PaymentRepository>();
            services.AddScoped<Business.Setting.Repositories.Interface.IResponseMessageRepository, Business.Setting.Repositories.ResponseMessageRepository>();
            services.AddScoped<Business.Setting.Repositories.Interface.IPreferencesRepository, Business.Setting.Repositories.PreferencesRepository>();

            // Streaming
            services.AddScoped<Business.Streaming.Repositories.Interface.IBookingQueueRepository, Business.Streaming.Repositories.BookingQueueRepository>();
            services.AddScoped<Business.Streaming.Repositories.Interface.IBookingUnlockRepository, Business.Streaming.Repositories.BookingUnlockRepository>();
            services.AddScoped<Business.Streaming.Repositories.Interface.ILiveRepository, Business.Streaming.Repositories.LiveRepository>();
            services.AddScoped<Business.Streaming.Repositories.Interface.ILiveCommentorRepository, Business.Streaming.Repositories.LiveCommentorRepository>();
            services.AddScoped<Business.Streaming.Repositories.Interface.ILiveOptionRepository, Business.Streaming.Repositories.LiveOptionRepository>();
            services.AddScoped<Business.Streaming.Repositories.Interface.IOfferingRepository, Business.Streaming.Repositories.OfferingRepository>();
        }

        private static void AddQueues(this IServiceCollection services)
        {
            services.AddHostedService<BillHostedService>();

            services.AddScoped<IQueueManager, QueueManager>();
            services.AddScoped<IQueueProvider, QueueProvider>();
        }

        private static void AddHandlers(this IServiceCollection services)
        {
            services.AddMediatR(typeof(Business.Startup));
        }

        private static void AddClients(this IServiceCollection services, IConfiguration configuration)
        {
            // Bank
            var bankServiceBaseUrl = configuration.GetValue<string>(AppSettings.Services.Bank.BaseUrl);
            services.AddClient<IBankServiceClient, BankServiceClient>(bankServiceBaseUrl);
            services.AddScoped<IBankServiceManager, BankServiceManager>();

            // Messaging
            var messagingBaseUrl = configuration.GetValue<string>(AppSettings.Services.Messaging.BaseUrl);
            services.AddClient<IMessagingServiceClient, MessagingServiceClient>(messagingBaseUrl);
            services.AddScoped<IMessagingServiceManager, MessagingServiceManager>();
        }

        private static void AddClient<TInterface, IImplementation>(this IServiceCollection services, string baseUrl)
            where TInterface : class
            where IImplementation : class, TInterface
        {
            services.AddHttpClient<TInterface, IImplementation>((client) =>
            {
                client.BaseAddress = new Uri(baseUrl);
            });
        }
    }
}