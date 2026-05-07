using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using laptopi.etf1.Data;
using laptopi.etf1.Models;

namespace laptopi.etf1.Controllers
{
    public class AdminModeratorsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminModeratorsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AdminModerators
        public async Task<IActionResult> Index()
        {
            return View(await _context.AdminModerator.ToListAsync());
        }

        // GET: AdminModerators/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adminModerator = await _context.AdminModerator
                .FirstOrDefaultAsync(m => m.adminModeratorId == id);
            if (adminModerator == null)
            {
                return NotFound();
            }

            return View(adminModerator);
        }

        // GET: AdminModerators/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AdminModerators/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("adminModeratorId,ime,email,uloga")] AdminModerator adminModerator)
        {
            if (ModelState.IsValid)
            {
                _context.Add(adminModerator);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(adminModerator);
        }

        // GET: AdminModerators/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adminModerator = await _context.AdminModerator.FindAsync(id);
            if (adminModerator == null)
            {
                return NotFound();
            }
            return View(adminModerator);
        }

        // POST: AdminModerators/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("adminModeratorId,ime,email,uloga")] AdminModerator adminModerator)
        {
            if (id != adminModerator.adminModeratorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(adminModerator);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdminModeratorExists(adminModerator.adminModeratorId))
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
            return View(adminModerator);
        }

        // GET: AdminModerators/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adminModerator = await _context.AdminModerator
                .FirstOrDefaultAsync(m => m.adminModeratorId == id);
            if (adminModerator == null)
            {
                return NotFound();
            }

            return View(adminModerator);
        }

        // POST: AdminModerators/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var adminModerator = await _context.AdminModerator.FindAsync(id);
            if (adminModerator != null)
            {
                _context.AdminModerator.Remove(adminModerator);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdminModeratorExists(int id)
        {
            return _context.AdminModerator.Any(e => e.adminModeratorId == id);
        }
    }
}
