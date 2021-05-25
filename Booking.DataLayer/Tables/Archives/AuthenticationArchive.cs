using System;
using System.ComponentModel.DataAnnotations;

namespace Booking.DataLayer.Tables.Archives
{
    public class AuthenticationArchive
    {
        [Key]
        public Guid Id { get; set; }
        
        public Guid ApplicationUserId { get; set; }
        
        public DateTimeOffset LastVisit { get; set; }
    }
}