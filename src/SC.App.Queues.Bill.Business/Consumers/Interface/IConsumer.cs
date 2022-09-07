using System.Threading.Tasks;
using RabbitMQ.Client;

namespace SC.App.Queues.Bill.Business.Consumers.Interface
{
    public interface IConsumer
    {
        public Task ConsumeAsync(IModel channel, ulong deliveryTag, byte[] body);
    }
}