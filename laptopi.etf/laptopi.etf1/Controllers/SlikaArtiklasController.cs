
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using laptopi.etf1.Models;
using laptopi.etf1.Data;

public class SlikaArtiklasController : Controller
{
    private readonly ApplicationDbContext _context;

    public SlikaArtiklasController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: SLIKAARTIKLAS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.SlikaArtikla.ToListAsync());
    }

    // GET: SLIKAARTIKLAS/Details/5
    public async Task<IActionResult> Details(int? slikaid)
    {
        if (slikaid == null)
        {
            return NotFound();
        }

        var slikaartikla = await _context.SlikaArtikla
            .FirstOrDefaultAsync(m => m.slikaId == slikaid);
        if (slikaartikla == null)
        {
            return NotFound();
        }

        return View(slikaartikla);
    }

    // GET: SLIKAARTIKLAS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: SLIKAARTIKLAS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("slikaId,putanjaDatoteke,artikalId")] SlikaArtikla slikaartikla)
    {
        if (ModelState.IsValid)
        {
            _context.Add(slikaartikla);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(slikaartikla);
    }

    // GET: SLIKAARTIKLAS/Edit/5
    public async Task<IActionResult> Edit(int? slikaid)
    {
        if (slikaid == null)
        {
            return NotFound();
        }

        var slikaartikla = await _context.SlikaArtikla.FindAsync(slikaid);
        if (slikaartikla == null)
        {
            return NotFound();
        }
        return View(slikaartikla);
    }

    // POST: SLIKAARTIKLAS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? slikaid, [Bind("slikaId,putanjaDatoteke,artikalId")] SlikaArtikla slikaartikla)
    {
        if (slikaid != slikaartikla.slikaId)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(slikaartikla);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SlikaArtiklaExists(slikaartikla.slikaId))
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
        return View(slikaartikla);
    }

    // GET: SLIKAARTIKLAS/Delete/5
    public async Task<IActionResult> Delete(int? slikaid)
    {
        if (slikaid == null)
        {
            return NotFound();
        }

        var slikaartikla = await _context.SlikaArtikla
            .FirstOrDefaultAsync(m => m.slikaId == slikaid);
        if (slikaartikla == null)
        {
            return NotFound();
        }

        return View(slikaartikla);
    }

    // POST: SLIKAARTIKLAS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? slikaid)
    {
        var slikaartikla = await _context.SlikaArtikla.FindAsync(slikaid);
        if (slikaartikla != null)
        {
            _context.SlikaArtikla.Remove(slikaartikla);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool SlikaArtiklaExists(int? slikaid)
    {
        return _context.SlikaArtikla.Any(e => e.slikaId == slikaid);
    }
}
