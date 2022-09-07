using System;
using System.Threading.Tasks;
using SC.App.Queues.Bill.Business.Streaming.Database.Models;
using SC.App.Queues.Bill.Business.Streaming.Enums;
using SC.App.Queues.Bill.Business.Streaming.Managers.Interface;
using SC.App.Queues.Bill.Business.Streaming.Repositories.Interface;
using SC.App.Queues.Bill.Common.Exceptions;

namespace SC.App.Queues.Bill.Business.Streaming.Managers
{
    public class BookingUnlockManager : IBookingUnlockManager
    {
        private readonly IBookingUnlockRepository _bookingUnlockRepository;
        private readonly ILiveRepository _liveRepository;
        private readonly ILiveCommentorRepository _liveCommentorRepository;

        public BookingUnlockManager(
            IBookingUnlockRepository bookingUnlockRepository,
            ILiveRepository liveRepository,
            ILiveCommentorRepository liveCommentorRepository)
        {
            _bookingUnlockRepository = bookingUnlockRepository;
            _liveRepository = liveRepository;
            _liveCommentorRepository = liveCommentorRepository;
        }

        public async Task UnlockBooking(Guid channelId, string name)
        {
            try
            {
                // Get latest connected live
                var latestConnectedLive = _liveRepository.GetLatestLiveByFilter(channelId, EnumLiveStatus.Connected);
                if (latestConnectedLive == null)
                {
                    throw new SkipProcessException("No live connected found.");
                }

                // Get live's commentor
                var liveCommentor = _liveCommentorRepository.GetByFilter(channelId, name);
                if (liveCommentor == null)
                {
                    throw new SkipProcessException("No live commentor found.");
                }

                // Get booking unlock
                var bookingUnlock = _bookingUnlockRepository.GetByUniqueKey(latestConnectedLive.Id, liveCommentor.Id);
                if (bookingUnlock == null)
                {
                    // Create
                    bookingUnlock = new BookingUnlock
                    {
                        LiveId = latestConnectedLive.Id,
                        LiveCommentorId = liveCommentor.Id,
                        Enabled = true
                    };

                    _ = _bookingUnlockRepository.Add(bookingUnlock);
                }
                else
                {
                    // Update
                    bookingUnlock.Enabled = true;

                    _bookingUnlockRepository.Update(bookingUnlock);
                }

                await Task.CompletedTask;
            }
            catch
            {
                throw;
            }
        }
    }
}