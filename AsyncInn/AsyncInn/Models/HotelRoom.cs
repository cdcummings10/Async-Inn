﻿namespace AsyncInn.Models
{
    public class HotelRoom
    {
        public int HotelID { get; set; }
        public int RoomNumber { get; set; }
        public int RoomID { get; set; }
        public decimal Rate { get; set; }
        public bool PetFriendly { get; set; }

        //nav props
        public Room Room { get; set; }
        public Hotel Hotel { get; set; }
    }
}