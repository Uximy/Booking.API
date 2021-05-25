using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Booking.DataLayer.Tables.Hotels;
using Booking.DataLayer.Tables.Users;

namespace Booking.DataLayer.Tables.Bookings
{
    public class Order : BaseEntity<Guid>
    {
        public Guid ApplicationUserId { get; set; }
        
        [ForeignKey(nameof(ApplicationUserId))]
        public virtual ApplicationUser Client { get; set; }
        
        [Range(1, 6)]
        public int PersonCount { get; set; }
        
        public Guid ApartmentId { get; set; }
        
        [ForeignKey(nameof(ApartmentId))]
        public virtual Apartment Apartment { get; set; }
        
        public virtual ICollection<Service> Services { get; set; }
        
        public DateTimeOffset CheckIn { get; set; }
        
        public DateTimeOffset CheckOut { get; set; }
        
        public decimal TotalPrice { get; set; }

        public Order()
        {
            Services = new List<Service>();
        }
    }
}