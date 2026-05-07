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
    public class SlikaArtiklaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SlikaArtiklaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SlikaArtikla
        public async Task<IActionResult> Index()
        {
            return View(await _context.SlikaArtikla.ToListAsync());
        }

        // GET: SlikaArtikla/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var slikaArtikla = await _context.SlikaArtikla
                .FirstOrDefaultAsync(m => m.slikaId == id);
            if (slikaArtikla == null)
            {
                return NotFound();
            }

            return View(slikaArtikla);
        }

        // GET: SlikaArtikla/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SlikaArtikla/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("slikaId,putanjaDatoteke,artikalId")] SlikaArtikla slikaArtikla)
        {
            if (ModelState.IsValid)
            {
                _context.Add(slikaArtikla);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(slikaArtikla);
        }

        // GET: SlikaArtikla/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var slikaArtikla = await _context.SlikaArtikla.FindAsync(id);
            if (slikaArtikla == null)
            {
                return NotFound();
            }
            return View(slikaArtikla);
        }

        // POST: SlikaArtikla/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("slikaId,putanjaDatoteke,artikalId")] SlikaArtikla slikaArtikla)
        {
            if (id != slikaArtikla.slikaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(slikaArtikla);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SlikaArtiklaExists(slikaArtikla.slikaId))
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
            return View(slikaArtikla);
        }

        // GET: SlikaArtikla/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var slikaArtikla = await _context.SlikaArtikla
                .FirstOrDefaultAsync(m => m.slikaId == id);
            if (slikaArtikla == null)
            {
                return NotFound();
            }

            return View(slikaArtikla);
        }

        // POST: SlikaArtikla/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var slikaArtikla = await _context.SlikaArtikla.FindAsync(id);
            if (slikaArtikla != null)
            {
                _context.SlikaArtikla.Remove(slikaArtikla);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SlikaArtiklaExists(int id)
        {
            return _context.SlikaArtikla.Any(e => e.slikaId == id);
        }
    }
}
