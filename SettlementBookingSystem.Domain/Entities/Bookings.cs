using SettlementBookingSystem.Domain.Common;
using System;

namespace SettlementBookingSystem.Domain.Entities
{
    public class Bookings : Entity
    {
        public Bookings(Guid id) : base(id)
        {
        }

        public string Name { get; set; }
        public string BookingTime { get; set; }
    }
}
