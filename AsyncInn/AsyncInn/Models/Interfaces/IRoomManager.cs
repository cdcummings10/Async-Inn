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
        Task UpdateRoom(int id);
        //Delete
        Task DeleteRoom(int id);
    }
}
