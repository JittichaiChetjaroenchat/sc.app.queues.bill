
using System;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RabbitMQ.Client;
using SC.App.Queues.Bill.Business.Consumers.Interface;
using SC.App.Queues.Bill.Business.Managers.Interface;
using SC.App.Queues.Bill.Common.Exceptions;
using SC.App.Queues.Bill.Queue.Models.Bill;
using Serilog;

namespace SC.App.Queues.Bill.Business.Consumers
{
    public class CancelBillConsumer : ICancelBillConsumer
    {
        private readonly IBillQueueManager _billQueueManager;

        public CancelBillConsumer(
            IBillQueueManager billQueueManager)
        {
            _billQueueManager = billQueueManager;
        }

        public async Task ConsumeAsync(IModel channel, ulong deliveryTag, byte[] body)
        {
            try
            {
                // Parse body
                var data = JsonConvert.DeserializeObject<CancelBill>(Encoding.UTF8.GetString(body));

                // Process
                await _billQueueManager.ProcessAsync(data);
            }
            catch (SkipProcessException ex)
            {
                Log.Information(ex.Message);
            }
            catch (Exception ex)
            {
                Log.Error(ex, string.Empty);
            }
            finally
            {
                if (channel.IsOpen)
                {
                    channel.BasicAck(deliveryTag, false);
                    // channel.Close();
                }
            }

            await Task.CompletedTask;
        }
    }
}