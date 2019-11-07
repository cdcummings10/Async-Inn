using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AsyncInn.Data;
using AsyncInn.Models;
using AsyncInn.Models.Interfaces;
using AsyncInn.Models.ViewModels;

namespace AsyncInn.Controllers
{
    public class RoomsController : Controller
    {
        private readonly IRoomManager _context;

        public RoomsController(IRoomManager context)
        {
            _context = context;
        }

        // GET: Rooms
        public async Task<IActionResult> Index()
        {
            return View(await _context.GetRooms());
        }

        // GET: Rooms/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            var room = await _context.GetRoom(id);
            if (room == null)
            {
                return NotFound();
            }

            return View(room);
        }

        // GET: Rooms/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Rooms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Layout")] Room room)
        {
            if (ModelState.IsValid)
            {
                await _context.CreateRoom(room);
                return RedirectToAction(nameof(Index));
            }
            return View(room);
        }

        // GET: Rooms/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            var room = await _context.GetRoom(id);
            var amenities = _context.GetAmenitiesAssociatedWithRoom(id);
            RoomAmenitiesVM ravm = new RoomAmenitiesVM();
            ravm.Room = room;
            ravm.Amenities = amenities;
            ravm.AmenitiesList = _context.GetAllAmenitiesList();
            ravm.RoomAmenitiesIDs = new int[ravm.Amenities.Count()];

            int count = 0;
            foreach (var item in ravm.Amenities)
            {
                ravm.RoomAmenitiesIDs[count] = item.AmenitiesID;
                count++;
            }
            if (room == null)
            {
                return NotFound();
            }
            return View(ravm);
        }

        // POST: Rooms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Layout")] Room room)
        {
            if (id != room.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _context.UpdateRoom(room);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (await RoomExists(room.ID) == false)
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(room);
        }

        // GET: Rooms/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            var room = await _context.GetRoom(id);
            if (room == null)
            {
                return NotFound();
            }

            return View(room);
        }

        // POST: Rooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _context.DeleteRoom(id);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> RoomExists(int id)
        {
            Room room = await _context.GetRoom(id);
            return room == null ? false : true;
        }

        //rooms/RemoveAmenity/ID object
        [HttpPost, ActionName("RemoveAmenity")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoveAmenity(int roomID, int amenityID)
        {
            await _context.RemoveAmenityFromRoom(roomID, amenityID);
            Room room = await _context.GetRoom(roomID);
            return View(room);
        }
    }
}
