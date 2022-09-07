using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SC.App.Queues.Bill.Common.Constants;
using SC.App.Queues.Bill.Configurations.Extensions;
using SC.App.Queues.Bill.Enums;
using SC.App.Queues.Bill.Lib.Extensions;

namespace SC.App.Queues.Bill
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add CORS
            services.AddCors(Configuration);

            // Add controllers
            var mvcBuilder = services.AddControllers(options =>
            {
                options.RespectBrowserAcceptHeader = true;
                options.OutputFormatters.Add(new XmlDataContractSerializerOutputFormatter());
            });

            // Add formatting
            mvcBuilder.AddJsonFormat();
            mvcBuilder.AddXmlFormat();

            // Add health checks
            services.AddHealthChecks(Configuration);

            // Add dependencies
            services.AddDependencies(Configuration);

            // Add databases
            services.AddDatabases(Configuration);

            // Add document
            services.AddRouting(options => options.LowercaseUrls = true);
            services.AddDocument(Configuration[AppSettings.Applications.Bill.Name]);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsEnvironment(EnumEnvironment.Local.GetDescription()) ||
                env.IsEnvironment(EnumEnvironment.Dev.GetDescription()))
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            // Use CORS
            app.UseCors(Configuration);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();

                // Use health checks
                endpoints.UseHealthChecks(Configuration);
            });

            // Use document
            app.UseDocument();
        }
    }
}