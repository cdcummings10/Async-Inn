using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Interfaces
{
    public interface IAmenitiesManager
    {
        //Create
        Task CreateAmenity(Amenities amenity);
        //Read
        Task<Amenities> GetAmenity(int id);
        Task<List<Amenities>> GetAmenities();
        //Update
        Task UpdateAmenity(Amenities amenity);
        //Delete
        Task DeleteAmenity(int id);

        Task<IEnumerable<RoomAmenities>> GetRoomsThatHaveAmenity(int amenityID);
    }
}
