using System.Collections.Generic;

namespace AsyncInn.Models
{
    public class Hotel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Phone { get; set; }

        //nav props
        ICollection<HotelRoom> HotelRooms { get; set; }
    }
}