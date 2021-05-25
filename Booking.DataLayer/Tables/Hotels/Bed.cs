using System.ComponentModel.DataAnnotations;

namespace Booking.DataLayer.Tables.Hotels
{
    public class Bed : BaseEntity<int>
    {
        [StringLength(25)]
        public string Name { get; set; }
        
        [Range(1, 4)]
        public int PlaceCount { get; set; }
    }
}