﻿using AsyncInn.Data;
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

        public async Task UpdateRoom(int id)
        {
            _context.Update(GetRoom(id));
            await _context.SaveChangesAsync();
        }
    }
}
