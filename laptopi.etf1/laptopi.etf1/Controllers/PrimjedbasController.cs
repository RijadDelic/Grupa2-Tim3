
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using laptopi.etf1.Models;
using laptopi.etf1.Data;

public class PrimjedbasController : Controller
{
    private readonly ApplicationDbContext _context;

    public PrimjedbasController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: PRIMJEDBAS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.Primjedba.ToListAsync());
    }

    // GET: PRIMJEDBAS/Details/5
    public async Task<IActionResult> Details(int? primjedbaid)
    {
        if (primjedbaid == null)
        {
            return NotFound();
        }

        var primjedba = await _context.Primjedba
            .FirstOrDefaultAsync(m => m.primjedbaId == primjedbaid);
        if (primjedba == null)
        {
            return NotFound();
        }

        return View(primjedba);
    }

    // GET: PRIMJEDBAS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: PRIMJEDBAS/Create
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

    // GET: PRIMJEDBAS/Edit/5
    public async Task<IActionResult> Edit(int? primjedbaid)
    {
        if (primjedbaid == null)
        {
            return NotFound();
        }

        var primjedba = await _context.Primjedba.FindAsync(primjedbaid);
        if (primjedba == null)
        {
            return NotFound();
        }
        return View(primjedba);
    }

    // POST: PRIMJEDBAS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? primjedbaid, [Bind("primjedbaId,sadrzaj,datumPrimjedbe,validnost,artikalId,korisnikId")] Primjedba primjedba)
    {
        if (primjedbaid != primjedba.primjedbaId)
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

    // GET: PRIMJEDBAS/Delete/5
    public async Task<IActionResult> Delete(int? primjedbaid)
    {
        if (primjedbaid == null)
        {
            return NotFound();
        }

        var primjedba = await _context.Primjedba
            .FirstOrDefaultAsync(m => m.primjedbaId == primjedbaid);
        if (primjedba == null)
        {
            return NotFound();
        }

        return View(primjedba);
    }

    // POST: PRIMJEDBAS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? primjedbaid)
    {
        var primjedba = await _context.Primjedba.FindAsync(primjedbaid);
        if (primjedba != null)
        {
            _context.Primjedba.Remove(primjedba);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool PrimjedbaExists(int? primjedbaid)
    {
        return _context.Primjedba.Any(e => e.primjedbaId == primjedbaid);
    }
}
