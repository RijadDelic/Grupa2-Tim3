using laptopi.etf1.Data;
using laptopi.etf1.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class KalendarController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;

    public KalendarController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    // GET: Kalendar/Upravljaj/5 - korisnik upravlja zauzetim datumima svog artikla
    [Authorize]
    public async Task<IActionResult> Upravljaj(int artikalId)
    {
        var artikal = await _context.Artikal.FindAsync(artikalId);
        if (artikal == null) return NotFound();

        var userId = _userManager.GetUserId(User);
        if (artikal.UserId != userId) return Forbid();

        var zauzetiDatumi = await _context.ZauzetDatum
            .Where(z => z.artikalId == artikalId)
            .Select(z => z.datum)
            .ToListAsync();

        ViewBag.ArtikalId = artikalId;
        ViewBag.ArtikalNaziv = artikal.naziv;
        ViewBag.ZauzetiDatumi = zauzetiDatumi;
        return View();
    }

    // POST: Kalendar/ToggleDatum - dodaj ili ukloni datum
    [HttpPost]
    [Authorize]
    public async Task<IActionResult> ToggleDatum(int artikalId, string datum)
    {
        var artikal = await _context.Artikal.FindAsync(artikalId);
        if (artikal == null) return Json(new { success = false });

        var userId = _userManager.GetUserId(User);
        if (artikal.UserId != userId) return Json(new { success = false });

        var date = DateOnly.Parse(datum);

        var postojeci = await _context.ZauzetDatum
            .FirstOrDefaultAsync(z => z.artikalId == artikalId && z.datum == date);

        if (postojeci != null)
        {
            _context.ZauzetDatum.Remove(postojeci);
            await _context.SaveChangesAsync();
            return Json(new { success = true, akcija = "uklonjen" });
        }
        else
        {
            _context.ZauzetDatum.Add(new ZauzetDatum
            {
                artikalId = artikalId,
                datum = date
            });
            await _context.SaveChangesAsync();
            return Json(new { success = true, akcija = "dodan" });
        }
    }

    // GET: Kalendar/ZauzetiDatumi/5 - za home modal
    public async Task<IActionResult> ZauzetiDatumi(int artikalId)
    {
        var datumi = await _context.ZauzetDatum
            .Where(z => z.artikalId == artikalId)
            .Select(z => z.datum.ToString("yyyy-MM-dd"))
            .ToListAsync();

        return Json(datumi);
    }
}
