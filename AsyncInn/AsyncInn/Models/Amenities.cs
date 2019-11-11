using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AsyncInn.Models
{
    public class Amenities
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }

        //nav prop
        public ICollection<RoomAmenities> RoomAmenities { get; set; }
    }
}