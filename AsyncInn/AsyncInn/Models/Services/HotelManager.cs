using AsyncInn.Data;
using AsyncInn.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Services
{
    public class HotelManager : IHotelManager
    {
        private AsyncInnDbContext _context;
        public HotelManager(AsyncInnDbContext context)
        {
            _context = context;
        }
        public async Task CreateHotel(Hotel hotel)
        {
            await _context.AddAsync(hotel);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteHotel(int id)
        {
            Hotel hotel = await GetHotel(id);
            _context.Remove(hotel);
            await _context.SaveChangesAsync();
        }

        public async Task<Hotel> GetHotel(int id) => await _context.Hotels.FirstOrDefaultAsync(hotel => hotel.ID == id);
        public Task<List<Hotel>> GetHotels()
        {
            var hotels = _context.Hotels.ToListAsync();
            return hotels;
        }

        public async Task UpdateHotel(Hotel hotel)
        {
            _context.Update(hotel);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<HotelRoom> GetRoomsInHotelRoom(int hotelID)
        {
            var rooms = _context.HotelRooms.Where(hotel => hotel.HotelID == hotelID)
                .Include(x => x.Hotel)
                .Include(x => x.Room);
            return rooms;
        }

        public async Task AddRoomToHotel(HotelRoom hotelRoom)
        {
            await _context.HotelRooms.AddAsync(hotelRoom);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveRoomFromHotel(int hotelID, int roomNumber)
        {
            HotelRoom room = await _context.HotelRooms.FirstOrDefaultAsync(x => x.HotelID == hotelID && x.RoomNumber == roomNumber);
            _context.Remove(room);
            await _context.SaveChangesAsync();
        }
    }
}
