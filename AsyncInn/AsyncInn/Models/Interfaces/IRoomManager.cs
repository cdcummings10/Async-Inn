using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Interfaces
{
    public interface IRoomManager
    {
        //Create
        Task CreateRoom(Room room);
        //Read
        Task<Room> GetRoom(int id);
        Task<List<Room>> GetRooms();
        //Update
        Task UpdateRoom(Room room);
        //Delete
        Task DeleteRoom(int id);
        Task<IEnumerable<RoomAmenities>> GetAmenitiesAssociatedWithRoom(int roomID);
        Task<IEnumerable<HotelRoom>> GetHotelsWhereRoomsAreLocated(int roomID);
    }
}
