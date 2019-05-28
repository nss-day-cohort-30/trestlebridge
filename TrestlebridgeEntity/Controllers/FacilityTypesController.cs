using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TrestlebridgeEntity.Data;
using TrestlebridgeEntity.Models;

namespace TrestlebridgeEntity.Controllers
{
    public class FacilityTypesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FacilityTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: FacilityTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.FacilityTypes.ToListAsync());
        }

        // GET: FacilityTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var facilityType = await _context.FacilityTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (facilityType == null)
            {
                return NotFound();
            }

            return View(facilityType);
        }

        // GET: FacilityTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FacilityTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Type")] FacilityType facilityType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(facilityType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(facilityType);
        }

        // GET: FacilityTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var facilityType = await _context.FacilityTypes.FindAsync(id);
            if (facilityType == null)
            {
                return NotFound();
            }
            return View(facilityType);
        }

        // POST: FacilityTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Type")] FacilityType facilityType)
        {
            if (id != facilityType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(facilityType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FacilityTypeExists(facilityType.Id))
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
            return View(facilityType);
        }

        // GET: FacilityTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var facilityType = await _context.FacilityTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (facilityType == null)
            {
                return NotFound();
            }

            return View(facilityType);
        }

        // POST: FacilityTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var facilityType = await _context.FacilityTypes.FindAsync(id);
            _context.FacilityTypes.Remove(facilityType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FacilityTypeExists(int id)
        {
            return _context.FacilityTypes.Any(e => e.Id == id);
        }
    }
}
