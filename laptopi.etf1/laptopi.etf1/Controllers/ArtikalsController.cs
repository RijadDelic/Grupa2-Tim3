
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using laptopi.etf1.Models;
using laptopi.etf1.Data;

public class ArtikalsController : Controller
{
    private readonly ApplicationDbContext _context;

    public ArtikalsController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: ARTIKALS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.Artikal.ToListAsync());
    }

    // GET: ARTIKALS/Details/5
    public async Task<IActionResult> Details(int? artikalid)
    {
        if (artikalid == null)
        {
            return NotFound();
        }

        var artikal = await _context.Artikal
            .FirstOrDefaultAsync(m => m.ArtikalId == artikalid);
        if (artikal == null)
        {
            return NotFound();
        }

        return View(artikal);
    }

    // GET: ARTIKALS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: ARTIKALS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("ArtikalId,naziv,opis,stranje,datumObjave,aktivnost,prosjecnaOcjena,kategorija")] Artikal artikal)
    {
        if (ModelState.IsValid)
        {
            _context.Add(artikal);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(artikal);
    }

    // GET: ARTIKALS/Edit/5
    public async Task<IActionResult> Edit(int? artikalid)
    {
        if (artikalid == null)
        {
            return NotFound();
        }

        var artikal = await _context.Artikal.FindAsync(artikalid);
        if (artikal == null)
        {
            return NotFound();
        }
        return View(artikal);
    }

    // POST: ARTIKALS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? artikalid, [Bind("ArtikalId,naziv,opis,stranje,datumObjave,aktivnost,prosjecnaOcjena,kategorija")] Artikal artikal)
    {
        if (artikalid != artikal.ArtikalId)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(artikal);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArtikalExists(artikal.ArtikalId))
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
        return View(artikal);
    }

    // GET: ARTIKALS/Delete/5
    public async Task<IActionResult> Delete(int? artikalid)
    {
        if (artikalid == null)
        {
            return NotFound();
        }

        var artikal = await _context.Artikal
            .FirstOrDefaultAsync(m => m.ArtikalId == artikalid);
        if (artikal == null)
        {
            return NotFound();
        }

        return View(artikal);
    }

    // POST: ARTIKALS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? artikalid)
    {
        var artikal = await _context.Artikal.FindAsync(artikalid);
        if (artikal != null)
        {
            _context.Artikal.Remove(artikal);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool ArtikalExists(int? artikalid)
    {
        return _context.Artikal.Any(e => e.ArtikalId == artikalid);
    }
}
