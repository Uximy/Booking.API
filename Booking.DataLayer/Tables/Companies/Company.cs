using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Booking.DataLayer.Tables.Hotels;

namespace Booking.DataLayer.Tables.Companies
{
    public class Company : BaseEntity<Guid>
    {
        [StringLength(128)]
        public string Name { get; set; }
        
        [StringLength(700)]
        public string Description { get; set; }
        
        public virtual ICollection<Hotel> Hotels { get; set; }
        
        public Company()
        {
            Hotels = new List<Hotel>();
        }
    }
}