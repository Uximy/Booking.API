using System;
using System.ComponentModel.DataAnnotations;

namespace Booking.DataLayer.Tables.Archives
{
    public class BookingArchive
    {
        [Key]
        public Guid Id { get; set; }
        
        public string Who { get; set; }
        
        public DateTimeOffset When { get; set; }
        
        public string What { get; set; }
    }
}