﻿using AsyncInn.Data;
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

        public async Task UpdateHotel(int id)
        {
            _context.Update(await GetHotel(id));
            await _context.SaveChangesAsync();
        }
    }
}