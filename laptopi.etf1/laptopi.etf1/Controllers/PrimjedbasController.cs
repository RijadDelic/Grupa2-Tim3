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
    public class PrimjedbasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PrimjedbasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Primjedbas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Primjedba.ToListAsync());
        }

        // GET: Primjedbas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var primjedba = await _context.Primjedba
                .FirstOrDefaultAsync(m => m.primjedbaId == id);
            if (primjedba == null)
            {
                return NotFound();
            }

            return View(primjedba);
        }

        // GET: Primjedbas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Primjedbas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("primjedbaId,sadrzaj,datumPrimjedbe,validnost,artikalId,korisnikId")] Primjedba primjedba)
        {
            if (ModelState.IsValid)
            {
                _context.Add(primjedba);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(primjedba);
        }

        // GET: Primjedbas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var primjedba = await _context.Primjedba.FindAsync(id);
            if (primjedba == null)
            {
                return NotFound();
            }
            return View(primjedba);
        }

        // POST: Primjedbas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("primjedbaId,sadrzaj,datumPrimjedbe,validnost,artikalId,korisnikId")] Primjedba primjedba)
        {
            if (id != primjedba.primjedbaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(primjedba);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PrimjedbaExists(primjedba.primjedbaId))
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
            return View(primjedba);
        }

        // GET: Primjedbas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var primjedba = await _context.Primjedba
                .FirstOrDefaultAsync(m => m.primjedbaId == id);
            if (primjedba == null)
            {
                return NotFound();
            }

            return View(primjedba);
        }

        // POST: Primjedbas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var primjedba = await _context.Primjedba.FindAsync(id);
            if (primjedba != null)
            {
                _context.Primjedba.Remove(primjedba);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PrimjedbaExists(int id)
        {
            return _context.Primjedba.Any(e => e.primjedbaId == id);
        }
    }
}
