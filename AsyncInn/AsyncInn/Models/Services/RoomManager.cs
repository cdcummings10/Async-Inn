using AsyncInn.Data;
using AsyncInn.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Services
{
    public class RoomManager : IRoomManager
    {
        private AsyncInnDbContext _context;
        public RoomManager(AsyncInnDbContext context)
        {
            _context = context;
        }
        public async Task CreateRoom(Room room)
        {
            await _context.AddAsync(room);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRoom(int id)
        {
            _context.Remove(await GetRoom(id));
            await _context.SaveChangesAsync();
        }

        public async Task<Room> GetRoom(int id) => await _context.Rooms.FirstOrDefaultAsync(room => room.ID == id);

        public async Task<List<Room>> GetRooms()
        {
            var rooms = await _context.Rooms.ToListAsync();
            return rooms;
        }

        public async Task UpdateRoom(Room room)
        {
            _context.Update(room);
            await _context.SaveChangesAsync();
        }

        public async Task AddAmenityToRoom(int roomID, int amenityID)
        {
            RoomAmenities newRoomAmenity = new RoomAmenities();
            newRoomAmenity.RoomID = roomID;
            newRoomAmenity.AmenitiesID = amenityID;
            _context.RoomAmenities.Add(newRoomAmenity);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAmenityFromRoom(int roomID, int amenityID)
        {
            RoomAmenities chosenToRemove = await _context.RoomAmenities.FirstOrDefaultAsync(x => x.RoomID == roomID && x.AmenitiesID == amenityID);
            _context.Remove(chosenToRemove);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<RoomAmenities> GetAmenitiesAssociatedWithRoom(int roomID)
        {
            var amenities = _context.RoomAmenities.Where(room => room.RoomID == roomID)
                .Include(x => x.Amenities)
                .Include(x => x.Room);
            return amenities;
        }

        public async Task<IEnumerable<Amenities>> GetAllAmenitiesList()
        {
            return await _context.Amenities.ToListAsync();
        }

        public async Task<IEnumerable<HotelRoom>> GetHotelsWhereRoomsAreLocated(int roomID)
        {
            var hotels = await _context.HotelRooms.Where(room => room.RoomID == roomID).ToListAsync();
            return hotels;
        }
    }
}
