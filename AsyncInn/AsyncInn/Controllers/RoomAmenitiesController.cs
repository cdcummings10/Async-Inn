﻿using System;
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
    public class RoomAmenitiesController : Controller
    {
        private readonly IRoomManager _rooms;
        private readonly IAmenitiesManager _amenities;

        public RoomAmenitiesController(IRoomManager rooms, IAmenitiesManager amenities)
        {
            _rooms = rooms;
            _amenities = amenities;
        }

        // GET: RoomAmenities/Details/5
        public async Task<IActionResult> Details(int id)
        {

            var roomAmenities = _rooms.GetAmenitiesAssociatedWithRoom(id);
            RoomAmenitiesVM ravm = new RoomAmenitiesVM();
            ravm.Room = await _rooms.GetRoom(id);
            ravm.Amenities = roomAmenities;
            ravm.RoomAmenitiesIDs = new int[ravm.Amenities.Count()];

            int count = 0;
            foreach(var item in ravm.Amenities)
            {
                ravm.RoomAmenitiesIDs[count] = item.AmenitiesID;
                count++;
            }


            return View(roomAmenities);
        }

        // GET: RoomAmenities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RoomAmenities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AmenitiesID,RoomID")] RoomAmenities roomAmenities)
        {
            if (ModelState.IsValid)
            {
                Room room = await _rooms.GetRoom(roomAmenities.RoomID);
                return RedirectToAction(nameof(Index));
            }
            return View(roomAmenities);
        }

        //// GET: RoomAmenities/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var roomAmenities = await _context.RoomAmenities.FindAsync(id);
        //    if (roomAmenities == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(roomAmenities);
        //}

        //// POST: RoomAmenities/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("AmenitiesID,RoomID")] RoomAmenities roomAmenities)
        //{
        //    if (id != roomAmenities.AmenitiesID)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(roomAmenities);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!RoomAmenitiesExists(roomAmenities.AmenitiesID))
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
        //    return View(roomAmenities);
        //}

        //// GET: RoomAmenities/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var roomAmenities = await _context.RoomAmenities
        //        .FirstOrDefaultAsync(m => m.AmenitiesID == id);
        //    if (roomAmenities == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(roomAmenities);
        //}

        //// POST: RoomAmenities/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var roomAmenities = await _context.RoomAmenities.FindAsync(id);
        //    _context.RoomAmenities.Remove(roomAmenities);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool RoomAmenitiesExists(int id)
        //{
        //    return _context.RoomAmenities.Any(e => e.AmenitiesID == id);
        //}
    }
}
