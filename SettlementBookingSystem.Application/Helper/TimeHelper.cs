using System;

namespace SettlementBookingSystem.Application.Helper
{
    public static class TimeHelper
    {
        public static DateTime ConvertFromHHMM(string input)
        {
            var canParseTime = TimeSpan.TryParse(input, out TimeSpan timeSpan);
            if (canParseTime)
            {
                var dateTime = DateTime.Today.Add(timeSpan);
                return dateTime;
            }
            return DateTime.Today;
        }
    }
}
