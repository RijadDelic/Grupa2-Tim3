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
    public class ZahtjevZaUklanjanjeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ZahtjevZaUklanjanjeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ZahtjevZaUklanjanje
        public async Task<IActionResult> Index()
        {
            return View(await _context.ZahtjevZaUklanjanje.ToListAsync());
        }

        // GET: ZahtjevZaUklanjanje/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zahtjevZaUklanjanje = await _context.ZahtjevZaUklanjanje
                .FirstOrDefaultAsync(m => m.zahtjevId == id);
            if (zahtjevZaUklanjanje == null)
            {
                return NotFound();
            }

            return View(zahtjevZaUklanjanje);
        }

        // GET: ZahtjevZaUklanjanje/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ZahtjevZaUklanjanje/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("zahtjevId,razlog,datumZahtjeva,status,artikalId,korisnikId,adminModeratorId")] ZahtjevZaUklanjanje zahtjevZaUklanjanje)
        {
            if (ModelState.IsValid)
            {
                _context.Add(zahtjevZaUklanjanje);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(zahtjevZaUklanjanje);
        }

        // GET: ZahtjevZaUklanjanje/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zahtjevZaUklanjanje = await _context.ZahtjevZaUklanjanje.FindAsync(id);
            if (zahtjevZaUklanjanje == null)
            {
                return NotFound();
            }
            return View(zahtjevZaUklanjanje);
        }

        // POST: ZahtjevZaUklanjanje/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("zahtjevId,razlog,datumZahtjeva,status,artikalId,korisnikId,adminModeratorId")] ZahtjevZaUklanjanje zahtjevZaUklanjanje)
        {
            if (id != zahtjevZaUklanjanje.zahtjevId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(zahtjevZaUklanjanje);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ZahtjevZaUklanjanjeExists(zahtjevZaUklanjanje.zahtjevId))
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
            return View(zahtjevZaUklanjanje);
        }

        // GET: ZahtjevZaUklanjanje/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zahtjevZaUklanjanje = await _context.ZahtjevZaUklanjanje
                .FirstOrDefaultAsync(m => m.zahtjevId == id);
            if (zahtjevZaUklanjanje == null)
            {
                return NotFound();
            }

            return View(zahtjevZaUklanjanje);
        }

        // POST: ZahtjevZaUklanjanje/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var zahtjevZaUklanjanje = await _context.ZahtjevZaUklanjanje.FindAsync(id);
            if (zahtjevZaUklanjanje != null)
            {
                _context.ZahtjevZaUklanjanje.Remove(zahtjevZaUklanjanje);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ZahtjevZaUklanjanjeExists(int id)
        {
            return _context.ZahtjevZaUklanjanje.Any(e => e.zahtjevId == id);
        }
    }
}
