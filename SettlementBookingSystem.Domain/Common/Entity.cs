using System;
using System.ComponentModel.DataAnnotations;

namespace SettlementBookingSystem.Domain.Common
{
    public abstract class Entity
    {
        protected Entity(Guid id)
        {
            Id = id;
        }

        [Key]
        public Guid Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
        public DateTime? DateDeleted { get; set; }
    }
}
