using System.ComponentModel.DataAnnotations;

namespace Booking.DataLayer.Tables.Hotels
{
    public class ApartmentType : BaseEntity<int>
    {
        [StringLength(20)]
        public string Name { get; set; }
    }
}