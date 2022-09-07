using System;

namespace SC.App.Queues.Streaming.Business.Setting.Repositories
{
    public class BaseRepository
    {
        protected readonly IServiceProvider ServiceProvider;

        public BaseRepository(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
        }
    }
}