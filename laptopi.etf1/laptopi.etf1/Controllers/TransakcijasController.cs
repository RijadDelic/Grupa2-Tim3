
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using laptopi.etf1.Models;
using laptopi.etf1.Data;

public class TransakcijasController : Controller
{
    private readonly ApplicationDbContext _context;

    public TransakcijasController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: TRANSAKCIJAS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.Transakcija.ToListAsync());
    }

    // GET: TRANSAKCIJAS/Details/5
    public async Task<IActionResult> Details(int? transakcijaid)
    {
        if (transakcijaid == null)
        {
            return NotFound();
        }

        var transakcija = await _context.Transakcija
            .FirstOrDefaultAsync(m => m.transakcijaId == transakcijaid);
        if (transakcija == null)
        {
            return NotFound();
        }

        return View(transakcija);
    }

    // GET: TRANSAKCIJAS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: TRANSAKCIJAS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("transakcijaId,artikalId,kupacId,prodavacId,tipTransakcije,status,datum,iznos")] Transakcija transakcija)
    {
        if (ModelState.IsValid)
        {
            _context.Add(transakcija);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(transakcija);
    }

    // GET: TRANSAKCIJAS/Edit/5
    public async Task<IActionResult> Edit(int? transakcijaid)
    {
        if (transakcijaid == null)
        {
            return NotFound();
        }

        var transakcija = await _context.Transakcija.FindAsync(transakcijaid);
        if (transakcija == null)
        {
            return NotFound();
        }
        return View(transakcija);
    }

    // POST: TRANSAKCIJAS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? transakcijaid, [Bind("transakcijaId,artikalId,kupacId,prodavacId,tipTransakcije,status,datum,iznos")] Transakcija transakcija)
    {
        if (transakcijaid != transakcija.transakcijaId)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(transakcija);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TransakcijaExists(transakcija.transakcijaId))
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
        return View(transakcija);
    }

    // GET: TRANSAKCIJAS/Delete/5
    public async Task<IActionResult> Delete(int? transakcijaid)
    {
        if (transakcijaid == null)
        {
            return NotFound();
        }

        var transakcija = await _context.Transakcija
            .FirstOrDefaultAsync(m => m.transakcijaId == transakcijaid);
        if (transakcija == null)
        {
            return NotFound();
        }

        return View(transakcija);
    }

    // POST: TRANSAKCIJAS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? transakcijaid)
    {
        var transakcija = await _context.Transakcija.FindAsync(transakcijaid);
        if (transakcija != null)
        {
            _context.Transakcija.Remove(transakcija);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool TransakcijaExists(int? transakcijaid)
    {
        return _context.Transakcija.Any(e => e.transakcijaId == transakcijaid);
    }
}
