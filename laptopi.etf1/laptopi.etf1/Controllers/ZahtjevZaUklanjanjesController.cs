
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using laptopi.etf1.Models;
using laptopi.etf1.Data;

public class ZahtjevZaUklanjanjesController : Controller
{
    private readonly ApplicationDbContext _context;

    public ZahtjevZaUklanjanjesController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: ZAHTJEVZAUKLANJANJES
    public async Task<IActionResult> Index()    
    {
        return View(await _context.ZahtjevZaUklanjanje.ToListAsync());
    }

    // GET: ZAHTJEVZAUKLANJANJES/Details/5
    public async Task<IActionResult> Details(int? zahtjevid)
    {
        if (zahtjevid == null)
        {
            return NotFound();
        }

        var zahtjevzauklanjanje = await _context.ZahtjevZaUklanjanje
            .FirstOrDefaultAsync(m => m.zahtjevId == zahtjevid);
        if (zahtjevzauklanjanje == null)
        {
            return NotFound();
        }

        return View(zahtjevzauklanjanje);
    }

    // GET: ZAHTJEVZAUKLANJANJES/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: ZAHTJEVZAUKLANJANJES/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("zahtjevId,razlog,datumZahtjeva,status,artikalId,korisnikId,adminModeratorId")] ZahtjevZaUklanjanje zahtjevzauklanjanje)
    {
        if (ModelState.IsValid)
        {
            _context.Add(zahtjevzauklanjanje);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(zahtjevzauklanjanje);
    }

    // GET: ZAHTJEVZAUKLANJANJES/Edit/5
    public async Task<IActionResult> Edit(int? zahtjevid)
    {
        if (zahtjevid == null)
        {
            return NotFound();
        }

        var zahtjevzauklanjanje = await _context.ZahtjevZaUklanjanje.FindAsync(zahtjevid);
        if (zahtjevzauklanjanje == null)
        {
            return NotFound();
        }
        return View(zahtjevzauklanjanje);
    }

    // POST: ZAHTJEVZAUKLANJANJES/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? zahtjevid, [Bind("zahtjevId,razlog,datumZahtjeva,status,artikalId,korisnikId,adminModeratorId")] ZahtjevZaUklanjanje zahtjevzauklanjanje)
    {
        if (zahtjevid != zahtjevzauklanjanje.zahtjevId)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(zahtjevzauklanjanje);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ZahtjevZaUklanjanjeExists(zahtjevzauklanjanje.zahtjevId))
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
        return View(zahtjevzauklanjanje);
    }

    // GET: ZAHTJEVZAUKLANJANJES/Delete/5
    public async Task<IActionResult> Delete(int? zahtjevid)
    {
        if (zahtjevid == null)
        {
            return NotFound();
        }

        var zahtjevzauklanjanje = await _context.ZahtjevZaUklanjanje
            .FirstOrDefaultAsync(m => m.zahtjevId == zahtjevid);
        if (zahtjevzauklanjanje == null)
        {
            return NotFound();
        }

        return View(zahtjevzauklanjanje);
    }

    // POST: ZAHTJEVZAUKLANJANJES/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? zahtjevid)
    {
        var zahtjevzauklanjanje = await _context.ZahtjevZaUklanjanje.FindAsync(zahtjevid);
        if (zahtjevzauklanjanje != null)
        {
            _context.ZahtjevZaUklanjanje.Remove(zahtjevzauklanjanje);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool ZahtjevZaUklanjanjeExists(int? zahtjevid)
    {
        return _context.ZahtjevZaUklanjanje.Any(e => e.zahtjevId == zahtjevid);
    }
}
