using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Booking.DataLayer.Tables.Bookings
{
    public class Check : BaseEntity<Guid>
    {
        public Guid OrderId { get; set; }
        
        [ForeignKey(nameof(OrderId))]
        public virtual Order Order { get; set; }
    }
}