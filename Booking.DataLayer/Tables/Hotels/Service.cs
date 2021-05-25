using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Booking.DataLayer.Tables.Hotels
{
    public class Service : BaseEntity<Guid>
    {
        public Guid HotelId { get; set; }
        
        [ForeignKey(nameof(HotelId))]
        public virtual Hotel Hotel { get; set; }
        
        public string Name { get; set; }
        
        public decimal Price { get; set; }
    }
}