using System;
using SC.App.Queues.Bill.Business.Streaming.Database.Models;
using SC.App.Queues.Bill.Common.Repositories;

namespace SC.App.Queues.Bill.Business.Streaming.Repositories.Interface
{
    public interface IBookingUnlockRepository : IRepository
    {
        BookingUnlock GetByUniqueKey(Guid liveId, Guid liveCommentorId);

        Guid Add(BookingUnlock bookingUnlock);

        void Update(BookingUnlock bookingUnlock);
    }
}