using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TrestlebridgeEntity.Data;
using TrestlebridgeEntity.Models;

namespace TrestlebridgeEntity.Controllers
{
    public class FarmsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        private Task<ApplicationUser> GetCurrentUserAsync() => 
            _userManager.GetUserAsync(HttpContext.User);



        public FarmsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Farms
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var user = await GetCurrentUserAsync();

            //var facilitiesFromSQL = _context.Facilities.FromSql(@"
            //    select f.RegisteredName, count(f.Id) NumberOfFaciities
            //    from Farms f
            //    join Facilities fc on fc.FarmId = f.Id
            //    group by f.RegisteredName
            //").ToList();

            var facilityCount = (from facility in _context.Facilities
                    group facility by new {
                        facility.FarmId,
                        facility.Farm.RegisteredName,
                        facility.Farm.Acres,
                        facility.Farm.User
                    }
                    into farmGroup
                    where farmGroup.Key.User == user
                    select new GroupedFarm
                    {
                        FarmId = farmGroup.Key.FarmId,
                        RegisteredName = farmGroup.Key.RegisteredName,
                        Acres = farmGroup.Key.Acres,
                        Count = farmGroup.Count()
                    }).ToList();


            return View(facilityCount);
        }

        // GET: Farms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var farm = await _context.Farms
                .FirstOrDefaultAsync(m => m.Id == id);
            if (farm == null)
            {
                return NotFound();
            }

            return View(farm);
        }

        // GET: Farms/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Farms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,RegisteredName,Acres")] Farm farm)
        {
            if (ModelState.IsValid)
            {
                var user = await GetCurrentUserAsync();
                farm.User = user;
                _context.Add(farm);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(farm);
        }

        // GET: Farms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var farm = await _context.Farms.FindAsync(id);
            if (farm == null)
            {
                return NotFound();
            }
            return View(farm);
        }

        // POST: Farms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,RegisteredName,Acres")] Farm farm)
        {
            if (id != farm.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(farm);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FarmExists(farm.Id))
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
            return View(farm);
        }

        // GET: Farms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var farm = await _context.Farms
                .FirstOrDefaultAsync(m => m.Id == id);
            if (farm == null)
            {
                return NotFound();
            }

            return View(farm);
        }

        // POST: Farms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var farm = await _context.Farms.FindAsync(id);
            _context.Farms.Remove(farm);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FarmExists(int id)
        {
            return _context.Farms.Any(e => e.Id == id);
        }
    }
}
