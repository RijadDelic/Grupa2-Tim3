
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using laptopi.etf1.Models;
using laptopi.etf1.Data;

public class OcjenaController : Controller
{
    private readonly ApplicationDbContext _context;

    public OcjenaController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: OCJENAS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.Ocjena.ToListAsync());
    }

    // GET: OCJENAS/Details/5
    public async Task<IActionResult> Details(int? ocjenaid)
    {
        if (ocjenaid == null)
        {
            return NotFound();
        }

        var ocjena = await _context.Ocjena
            .FirstOrDefaultAsync(m => m.ocjenaId == ocjenaid);
        if (ocjena == null)
        {
            return NotFound();
        }

        return View(ocjena);
    }

    // GET: OCJENAS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: OCJENAS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("ocjenaId,vrijednost,datumOcjenjivanja,artikalId,korisnikId")] Ocjena ocjena)
    {
        if (ModelState.IsValid)
        {
            _context.Add(ocjena);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(ocjena);
    }

    // GET: OCJENAS/Edit/5
    public async Task<IActionResult> Edit(int? ocjenaid)
    {
        if (ocjenaid == null)
        {
            return NotFound();
        }

        var ocjena = await _context.Ocjena.FindAsync(ocjenaid);
        if (ocjena == null)
        {
            return NotFound();
        }
        return View(ocjena);
    }

    // POST: OCJENAS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? ocjenaid, [Bind("ocjenaId,vrijednost,datumOcjenjivanja,artikalId,korisnikId")] Ocjena ocjena)
    {
        if (ocjenaid != ocjena.ocjenaId)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(ocjena);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OcjenaExists(ocjena.ocjenaId))
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
        return View(ocjena);
    }

    // GET: OCJENAS/Delete/5
    public async Task<IActionResult> Delete(int? ocjenaid)
    {
        if (ocjenaid == null)
        {
            return NotFound();
        }

        var ocjena = await _context.Ocjena
            .FirstOrDefaultAsync(m => m.ocjenaId == ocjenaid);
        if (ocjena == null)
        {
            return NotFound();
        }

        return View(ocjena);
    }

    // POST: OCJENAS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? ocjenaid)
    {
        var ocjena = await _context.Ocjena.FindAsync(ocjenaid);
        if (ocjena != null)
        {
            _context.Ocjena.Remove(ocjena);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool OcjenaExists(int? ocjenaid)
    {
        return _context.Ocjena.Any(e => e.ocjenaId == ocjenaid);
    }
}
