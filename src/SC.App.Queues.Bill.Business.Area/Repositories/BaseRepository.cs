﻿using System;

namespace SC.App.Queues.Bill.Business.Area.Repositories
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