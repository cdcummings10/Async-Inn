using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.ViewModels
{
    public class RoomAmenitiesVM
    {
        public IEnumerable<RoomAmenities> Amenities { get; set; }
        public Room Room { get; set; }
        public IEnumerable<Amenities> AmenitiesList { get; set; }
        public int[] RoomAmenitiesIDs { get; set; }

    }
}
