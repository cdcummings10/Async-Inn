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

namespace AsyncInn.Controllers
{
    public class HotelRoomsController : Controller
    {
        private readonly IHotelManager _hotels;
        private readonly IRoomManager _rooms;

        public HotelRoomsController(IHotelManager hotels, IRoomManager rooms)
        {
            _hotels = hotels;
            _rooms = rooms;
        }

        // GET: HotelRooms/Details/5
        public IActionResult Details(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            var hotelRooms = _hotels.GetRoomsInHotelRoom(id);

            return View(hotelRooms);
        }

        // GET: HotelRooms/Create
        public async Task<IActionResult> Create()
        {
            ViewData["HotelID"] = new SelectList(await _hotels.GetHotels(), "ID", "Name");
            ViewData["RoomID"] = new SelectList(await _rooms.GetRooms(), "ID", "Name");
            return View();
        }

        // POST: HotelRooms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("HotelID,RoomNumber,RoomID,Rate,PetFriendly")] HotelRoom hotelRoom)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(hotelRoom);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(hotelRoom);
        //}

        //// GET: HotelRooms/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var hotelRoom = await _context.HotelRooms.FindAsync(id);
        //    if (hotelRoom == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(hotelRoom);
        //}

        //// POST: HotelRooms/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("HotelID,RoomNumber,RoomID,Rate,PetFriendly")] HotelRoom hotelRoom)
        //{
        //    if (id != hotelRoom.HotelID)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(hotelRoom);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!HotelRoomExists(hotelRoom.HotelID))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(hotelRoom);
        //}

        //// GET: HotelRooms/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var hotelRoom = await _context.HotelRooms
        //        .FirstOrDefaultAsync(m => m.HotelID == id);
        //    if (hotelRoom == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(hotelRoom);
        //}

        //// POST: HotelRooms/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var hotelRoom = await _context.HotelRooms.FindAsync(id);
        //    _context.HotelRooms.Remove(hotelRoom);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool HotelRoomExists(int id)
        //{
        //    return _context.HotelRooms.Any(e => e.HotelID == id);
        //}
    }
}
