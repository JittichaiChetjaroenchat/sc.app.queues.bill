namespace SC.App.Queues.Bill.Queue.Providers.Interface
{
    public interface IQueueProvider
    {
        public void Publish<T>(string queue, string exchange, string routingKey, T payload);
    }
}