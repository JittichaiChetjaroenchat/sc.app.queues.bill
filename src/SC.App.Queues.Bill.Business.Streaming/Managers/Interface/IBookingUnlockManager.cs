using System;
using System.Threading.Tasks;

namespace SC.App.Queues.Bill.Business.Streaming.Managers.Interface
{
    public interface IBookingUnlockManager
    {
        Task UnlockBooking(Guid channelId, string name);
    }
}