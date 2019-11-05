using AsyncInn.Data;
using AsyncInn.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Services
{
    public class AmenitiesManager : IAmenitiesManager
    {
        private AsyncInnDbContext _context;
        public AmenitiesManager(AsyncInnDbContext context)
        {
            _context = context;
        }

        public async Task CreateAmenity(Amenities amenity)
        {
            await _context.AddAsync(amenity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAmenity(int id)
        {
            _context.Remove(await GetAmenity(id));
            await _context.SaveChangesAsync();
        }
        public async Task<Amenities> GetAmenity(int id) => await _context.Amenities.FirstOrDefaultAsync(amen => amen.ID == id);

        public Task<List<Amenities>> GetAmenities()
        {
            var amenities = _context.Amenities.ToListAsync();
            return amenities;
        }


        public async Task UpdateAmenity(int id)
        {
            _context.Update(await GetAmenity(id));
            await _context.SaveChangesAsync();
        }
    }
}
