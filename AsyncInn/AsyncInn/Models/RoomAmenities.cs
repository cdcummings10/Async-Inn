namespace AsyncInn.Models
{
    public class RoomAmenities
    {
        public int AmenitiesID { get; set; }
        public int RoomID { get; set; }

        //nav props
        public Amenities Amenities { get; set; }
        public Room Room { get; set; }
    }
}