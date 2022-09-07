using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using SC.App.Queues.Bill.Configurations.Extensions;

namespace SC.App.Queues.Bill
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureLog()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}