using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.ViewModels
{
    public class HotelRoomVM
    {
        public IEnumerable<HotelRoom> HotelRooms { get; set; }
        public Hotel Hotel { get; set; }
        public IEnumerable<Room> Rooms { get; set; }

    }
}
