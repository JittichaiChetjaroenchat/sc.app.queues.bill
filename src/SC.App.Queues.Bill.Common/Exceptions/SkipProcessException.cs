using System;

namespace SC.App.Queues.Bill.Common.Exceptions
{
    public class SkipProcessException : Exception
    {
        public SkipProcessException(string message)
            : base(message)
        {
        }
    }
}