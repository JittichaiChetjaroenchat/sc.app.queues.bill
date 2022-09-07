using System;

namespace SC.App.Queues.Bill.Lib.Helpers
{
    public static class DateTimeHelper
    {
        public static DateTime FromDays(int unixTimestamp, int defaultDays)
        {
            if (unixTimestamp > 0)
            {
                return Convert(unixTimestamp);
            }

            int defaultUnixTimestamp = (int)(DateTime.UtcNow.AddDays(defaultDays).Subtract(new DateTime(1970, 1, 1))).TotalSeconds;

            return Convert(defaultUnixTimestamp);
        }

        public static DateTime Convert(int unixTimestamp)
        {
            var dt = DateTimeOffset.FromUnixTimeSeconds(unixTimestamp);

            return dt.UtcDateTime;
        }

        public static long Convert(DateTime dateTime)
        {
            return ((DateTimeOffset)dateTime).ToUnixTimeSeconds();
        }
    }
}