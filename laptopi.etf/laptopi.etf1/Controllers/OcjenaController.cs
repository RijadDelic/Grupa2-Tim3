using laptopi.etf1.Data;
using laptopi.etf1.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class OcjenaController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;

    public OcjenaController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Ocijeni(string ocjenjenId, int vrijednost)
    {
        var ocjenjivacId = _userManager.GetUserId(User);

        // Ne može ocijeniti sam sebe
        if (ocjenjenId == ocjenjivacId)
            return Json(new { success = false, poruka = "Ne možete ocijeniti sami sebe." });

        // Provjeri da li je već ocijenio
        var postojecaOcjena = await _context.Ocjena
            .FirstOrDefaultAsync(o => o.ocjenjenId == ocjenjenId && o.ocjenjivacId == ocjenjivacId);

        if (postojecaOcjena != null)
            return Json(new { success = false, poruka = "Već ste ocijenili ovog korisnika." });

        // Spremi ocjenu
        var ocjena = new Ocjena
        {
            ocjenjenId = ocjenjenId,
            ocjenjivacId = ocjenjivacId,
            vrijednost = vrijednost,
            datumOcjenjivanja = DateOnly.FromDateTime(DateTime.Now)
        };

        _context.Ocjena.Add(ocjena);
        await _context.SaveChangesAsync();

        // Izračunaj novu prosječnu ocjenu korisnika
        var prosjecna = await _context.Ocjena
            .Where(o => o.ocjenjenId == ocjenjenId)
            .AverageAsync(o => o.vrijednost);

        return Json(new { success = true, prosjecna = prosjecna.ToString("0.0") });
    }
}
