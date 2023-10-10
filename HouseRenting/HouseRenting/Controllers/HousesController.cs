using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HouseRenting.Data;
using HouseRenting.Models;

namespace HouseRenting.Controllers
{
    public class HousesController : Controller
    {
        private readonly HouseDbContext _context;

        public HousesController(HouseDbContext context)
        {
            _context = context;
        }

        // GET: Houses
        public async Task<IActionResult> Index()
        {
              return _context.House != null ? 
                          View(await _context.House.ToListAsync()) :
                          Problem("Entity set 'HouseDbContext.House'  is null.");
        }

        // GET: Houses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.House == null)
            {
                return NotFound();
            }

            var house = await _context.House
                .FirstOrDefaultAsync(m => m.ID == id);
            if (house == null)
            {
                return NotFound();
            }

            return View(house);
        }

        // GET: Houses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Houses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Type,Color,Area,Price,NumberOfRooms,Location,ConstructionDate,Description")] House house)
        {
            if (ModelState.IsValid)
            {
                _context.Add(house);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(house);
        }

        // GET: Houses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.House == null)
            {
                return NotFound();
            }

            var house = await _context.House.FindAsync(id);
            if (house == null)
            {
                return NotFound();
            }
            return View(house);
        }

        // POST: Houses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Type,Color,Area,Price,NumberOfRooms,Location,ConstructionDate,Description")] House house)
        {
            if (id != house.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(house);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HouseExists(house.ID))
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
            return View(house);
        }

        // GET: Houses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.House == null)
            {
                return NotFound();
            }

            var house = await _context.House
                .FirstOrDefaultAsync(m => m.ID == id);
            if (house == null)
            {
                return NotFound();
            }

            return View(house);
        }

        // POST: Houses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.House == null)
            {
                return Problem("Entity set 'HouseDbContext.House'  is null.");
            }
            var house = await _context.House.FindAsync(id);
            if (house != null)
            {
                _context.House.Remove(house);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HouseExists(int id)
        {
          return (_context.House?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
