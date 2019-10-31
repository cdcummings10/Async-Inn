using System.Collections.Generic;

namespace AsyncInn.Models
{
    public class Amenities
    {
        public int ID { get; set; }
        public string Name { get; set; }

        //nav prop
        ICollection<RoomAmenities> RoomAmenities { get; set; }
    }
}