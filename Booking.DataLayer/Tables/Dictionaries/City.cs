using System.ComponentModel.DataAnnotations.Schema;

namespace Booking.DataLayer.Tables.Dictionaries
{
    public class City
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int CountryId { get; set; }

        [ForeignKey(nameof(CountryId))]
        public virtual Country Country { get; set; }
    }
}