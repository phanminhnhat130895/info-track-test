using SettlementBookingSystem.Domain.Entities;
using System;
using System.Collections.Generic;

namespace SettlementBookingSystem.Infrastructure.Data
{
    public sealed class BookingContext
    {
        private BookingContext() { }

        private static List<Bookings> tableBooking { get; set; } = new List<Bookings>()
        {
            new Bookings(Guid.NewGuid()) { Name = "test", BookingTime = "13:15", DateCreated = DateTime.Now },
            new Bookings(Guid.NewGuid()) { Name = "test", BookingTime = "13:15", DateCreated = DateTime.Now },
            new Bookings(Guid.NewGuid()) { Name = "test", BookingTime = "13:15", DateCreated = DateTime.Now },
            new Bookings(Guid.NewGuid()) { Name = "test", BookingTime = "13:15", DateCreated = DateTime.Now },
        };

        public static List<Bookings> TableBooking
        {
            get
            {
                return tableBooking;
            }
        }
    }
}
