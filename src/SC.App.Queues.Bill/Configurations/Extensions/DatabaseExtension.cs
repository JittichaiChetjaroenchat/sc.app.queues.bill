using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SC.App.Queues.Bill.Common.Constants;

namespace SC.App.Queues.Bill.Configurations.Extensions
{
    public static class DatabaseExtension
    {
        public static void AddDatabases(this IServiceCollection services, IConfiguration configuration)
        {
            AddAreaDatabase(services, configuration);
            AddBillDatabase(services, configuration);
            AddCreditDatabase(services, configuration);
            AddCourierDatabase(services, configuration);
            AddCustomerDatabase(services, configuration);
            AddInventoryDatabase(services, configuration);
            AddOrderDatabase(services, configuration);
            AddSettingDatabase(services, configuration);
            AddStreamingDatabase(services, configuration);
        }

        private static void AddAreaDatabase(IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetValue<string>(AppSettings.Databases.Area.ConnectionString);

            // Add database context
            var version = ServerVersion.AutoDetect(connectionString);
            services.AddDbContextPool<Business.Area.Database.DatabaseContext>(options =>
            {
                options.UseMySql(connectionString, version)
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors();
            });
        }

        private static void AddBillDatabase(IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetValue<string>(AppSettings.Databases.Bill.ConnectionString);

            // Add database context
            var version = ServerVersion.AutoDetect(connectionString);
            services.AddDbContextPool<Database.DatabaseContext>(options =>
            {
                options.UseMySql(connectionString, version)
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors();
            });
        }

        private static void AddCourierDatabase(IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetValue<string>(AppSettings.Databases.Courier.ConnectionString);

            // Add database context
            var version = ServerVersion.AutoDetect(connectionString);
            services.AddDbContextPool<Business.Courier.Database.DatabaseContext>(options =>
            {
                options.UseMySql(connectionString, version)
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors();
            });
        }

        private static void AddCreditDatabase(IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetValue<string>(AppSettings.Databases.Credit.ConnectionString);

            // Add database context
            var version = ServerVersion.AutoDetect(connectionString);
            services.AddDbContextPool<Business.Credit.Database.DatabaseContext>(options =>
            {
                options.UseMySql(connectionString, version)
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors();
            });
        }

        private static void AddCustomerDatabase(IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetValue<string>(AppSettings.Databases.Customer.ConnectionString);

            // Add database context
            var version = ServerVersion.AutoDetect(connectionString);
            services.AddDbContextPool<Business.Customer.Database.DatabaseContext>(options =>
            {
                options.UseMySql(connectionString, version)
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors();
            });
        }

        private static void AddInventoryDatabase(IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetValue<string>(AppSettings.Databases.Inventory.ConnectionString);

            // Add database context
            var version = ServerVersion.AutoDetect(connectionString);
            services.AddDbContextPool<Business.Inventory.Database.DatabaseContext>(options =>
            {
                options.UseMySql(connectionString, version)
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors();
            });
        }

        private static void AddOrderDatabase(IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetValue<string>(AppSettings.Databases.Order.ConnectionString);

            // Add database context
            var version = ServerVersion.AutoDetect(connectionString);
            services.AddDbContextPool<Business.Order.Database.DatabaseContext>(options =>
            {
                options.UseMySql(connectionString, version)
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors();
            });
        }

        private static void AddSettingDatabase(IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetValue<string>(AppSettings.Databases.Setting.ConnectionString);

            // Add database context
            var version = ServerVersion.AutoDetect(connectionString);
            services.AddDbContextPool<Business.Setting.Database.DatabaseContext>(options =>
            {
                options.UseMySql(connectionString, version)
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors();
            });
        }

        private static void AddStreamingDatabase(IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetValue<string>(AppSettings.Databases.Streaming.ConnectionString);

            // Add database context
            var version = ServerVersion.AutoDetect(connectionString);
            services.AddDbContextPool<Business.Streaming.Database.DatabaseContext>(options =>
            {
                options.UseMySql(connectionString, version)
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors();
            });
        }
    }
}