
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using laptopi.etf1.Models;
using laptopi.etf1.Data;

public class RezervacijasController : Controller
{
    private readonly ApplicationDbContext _context;

    public RezervacijasController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: REZERVACIJAS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.Rezervacija.ToListAsync());
    }

    // GET: REZERVACIJAS/Details/5
    public async Task<IActionResult> Details(int? rezervacijaid)
    {
        if (rezervacijaid == null)
        {
            return NotFound();
        }

        var rezervacija = await _context.Rezervacija
            .FirstOrDefaultAsync(m => m.rezervacijaId == rezervacijaid);
        if (rezervacija == null)
        {
            return NotFound();
        }

        return View(rezervacija);
    }

    // GET: REZERVACIJAS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: REZERVACIJAS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("rezervacijaId,datumOd,datumDo,status,datumZahtjeva,korisnikId")] Rezervacija rezervacija)
    {
        if (ModelState.IsValid)
        {
            _context.Add(rezervacija);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(rezervacija);
    }

    // GET: REZERVACIJAS/Edit/5
    public async Task<IActionResult> Edit(int? rezervacijaid)
    {
        if (rezervacijaid == null)
        {
            return NotFound();
        }

        var rezervacija = await _context.Rezervacija.FindAsync(rezervacijaid);
        if (rezervacija == null)
        {
            return NotFound();
        }
        return View(rezervacija);
    }

    // POST: REZERVACIJAS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? rezervacijaid, [Bind("rezervacijaId,datumOd,datumDo,status,datumZahtjeva,korisnikId")] Rezervacija rezervacija)
    {
        if (rezervacijaid != rezervacija.rezervacijaId)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(rezervacija);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RezervacijaExists(rezervacija.rezervacijaId))
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
        return View(rezervacija);
    }

    // GET: REZERVACIJAS/Delete/5
    public async Task<IActionResult> Delete(int? rezervacijaid)
    {
        if (rezervacijaid == null)
        {
            return NotFound();
        }

        var rezervacija = await _context.Rezervacija
            .FirstOrDefaultAsync(m => m.rezervacijaId == rezervacijaid);
        if (rezervacija == null)
        {
            return NotFound();
        }

        return View(rezervacija);
    }

    // POST: REZERVACIJAS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? rezervacijaid)
    {
        var rezervacija = await _context.Rezervacija.FindAsync(rezervacijaid);
        if (rezervacija != null)
        {
            _context.Rezervacija.Remove(rezervacija);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool RezervacijaExists(int? rezervacijaid)
    {
        return _context.Rezervacija.Any(e => e.rezervacijaId == rezervacijaid);
    }
}
