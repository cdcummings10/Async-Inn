using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Interfaces
{
    public interface IHotelManager
    {
        //Create
        Task CreateHotel(Hotel hotel);
        //Read
        Task<Hotel> GetHotel(int id);
        Task<List<Hotel>> GetHotels();
        //Update
        Task UpdateHotel(Hotel hotel);
        //Delete
        Task DeleteHotel(int id);
        Task AddRoomToHotel(HotelRoom hotelRoom);
        Task RemoveRoomFromHotel(int hotelID, int roomNumber);
        IEnumerable<HotelRoom> GetRoomsInHotelRoom(int hotelID);

    }
}
