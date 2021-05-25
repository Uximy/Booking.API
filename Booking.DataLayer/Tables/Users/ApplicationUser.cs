using System;
using System.ComponentModel.DataAnnotations.Schema;
using Booking.DataLayer.Tables.Dictionaries;
using Microsoft.AspNetCore.Identity;

namespace Booking.DataLayer.Tables.Users
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public int CityId { get; set; }
        
        [ForeignKey(nameof(CityId))]
        public virtual City City { get; set; }
    }
}