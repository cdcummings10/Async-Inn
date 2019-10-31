namespace AsyncInn.Models
{
    public class RoomAmenities
    {
        public int AmenitiesID { get; set; }
        public int RoomID { get; set; }

        //nav props
        Amenities Amenities { get; set; }
        Room Room { get; set; }
    }
}