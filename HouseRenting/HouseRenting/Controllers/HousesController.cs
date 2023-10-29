using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HouseRenting.ViewModels;
using HouseRenting.Data;
using HouseRenting.Models;


using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using Microsoft.AspNetCore.Authorization;
namespace HouseRenting.Controllers
{
    public class HousesController : Controller
    {
        private readonly HouseDbContext _context;
        private readonly IWebHostEnvironment hosting;

        public HousesController(HouseDbContext context, IWebHostEnvironment hosting)
        {
            _context = context;
            this.hosting = hosting;
        }

        
    

    // GET: Houses
    public async Task<IActionResult> Index(
     string sortOrder,
     string currentFilter,
     string searchString,
     int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["TypeSortParm"] = sortOrder == "Type" ? "Type_desc" : "Type";
            ViewData["PriceSortParm"] = sortOrder == "Price" ? "Price_desc" : "Price"; // Corrected ViewData key
            ViewData["CurrentFilter"] = searchString;
            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            var houses = from s in _context.House
                         select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                houses = houses.Where(s => s.Type.Contains(searchString) || s.Price.ToString().Contains(searchString));
            }
            switch (sortOrder)
            {
                case "Type_desc":
                    houses = houses.OrderByDescending(s => s.Type);
                    break;
                case "Price_desc":
                    houses = houses.OrderByDescending(s => s.Price);
                    break;
                case "Price":
                    houses = houses.OrderBy(s => s.Price);
                    break;
                case "Type":
                    houses = houses.OrderBy(s => s.Type);
                    break;
                default:
                    houses = houses.OrderBy(s => s.Type);
                    break;
            }
            int pageSize = 4;
            return View(await PaginatedList<House>.CreateAsync(houses.AsNoTracking(), pageNumber ?? 1, pageSize));
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


        private async Task<string> UploadFileAsync(IFormFile file, string targetFolder)
        {
            if (file == null || file.Length <= 0)
            {
                return null;
            }

            string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            string targetPath = Path.Combine(targetFolder, fileName);

            using (var stream = new FileStream(targetPath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return fileName;
        }
        // POST: Houses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Type,Color,Area,Price,Rooms,Location,ConstructionDate,Description, ImagePath")] House house, HouseViewModel viewModels)
        {
            if (ModelState.IsValid)
            {
                // Call UploadFileAsync method to handle file upload
                string imagesFolderPath = Path.Combine(hosting.WebRootPath, "Images");
                string fileName = await UploadFileAsync(viewModels.File, imagesFolderPath);

                if (!string.IsNullOrEmpty(fileName))
                {
                    house.ImagePath = fileName;
                }

                _context.Add(house);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            // If ModelState is not valid, return the same view with the BoardsView object
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
        public async Task<IActionResult> Edit(int id, [Bind("ID,Type,Color,Area,Price,Rooms,Location,ConstructionDate,Description")] House house)
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
