using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Gym.Models;

namespace Gym.Controllers
{
    public class MembershipsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MembershipsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Memberships
        public async Task<IActionResult> Index()
        {
            return View(await _context.Memberships.ToListAsync());
        }

        // GET: Memberships/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var memberships = await _context.Memberships
                .FirstOrDefaultAsync(m => m.MembershipID == id);
            if (memberships == null)
            {
                return NotFound();
            }

            return View(memberships);
        }

        // GET: Memberships/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Memberships/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MembershipID,MembershipType,StartDate,EndDate")] Memberships memberships)
        {
            if (ModelState.IsValid)
            {
                _context.Add(memberships);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(memberships);
        }

        // GET: Memberships/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var memberships = await _context.Memberships.FindAsync(id);
            if (memberships == null)
            {
                return NotFound();
            }
            return View(memberships);
        }

        // POST: Memberships/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MembershipID,MembershipType,StartDate,EndDate")] Memberships memberships)
        {
            if (id != memberships.MembershipID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(memberships);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MembershipsExists(memberships.MembershipID))
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
            return View(memberships);
        }

        // GET: Memberships/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var memberships = await _context.Memberships
                .FirstOrDefaultAsync(m => m.MembershipID == id);
            if (memberships == null)
            {
                return NotFound();
            }

            return View(memberships);
        }

        // POST: Memberships/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var memberships = await _context.Memberships.FindAsync(id);
            _context.Memberships.Remove(memberships);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MembershipsExists(int id)
        {
            return _context.Memberships.Any(e => e.MembershipID == id);
        }
    }
}
