using laptopi.etf1.Data;
using laptopi.etf1.Models;
using laptopi.etf1.Models.@enum;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class HomeController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;

    public HomeController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    public async Task<IActionResult> Index(string? pretraga, string? stanje, string? tipTransakcije, string? sortiranje, string? cijenaRange)
    {
        var artikli = _context.Artikal.Include(a => a.Slike).AsQueryable();

        if (!string.IsNullOrEmpty(pretraga))
            artikli = artikli.Where(a => a.naziv.Contains(pretraga) || a.opis.Contains(pretraga));

        if (stanje == "Novo")
            artikli = artikli.Where(a => a.stranje == Stanje.Novo);
        else if (stanje == "Polovno")
            artikli = artikli.Where(a => a.stranje == Stanje.Polovno);

        if (tipTransakcije == "Prodaja")
            artikli = artikli.Where(a => a.tipTransakcije == TipTransakcije.Prodaja);
        else if (tipTransakcije == "Iznajmljivanje")
            artikli = artikli.Where(a => a.tipTransakcije == TipTransakcije.Iznajmljivanje);

        // Price range filter
        if (!string.IsNullOrEmpty(cijenaRange) && cijenaRange != "all")
        {
            switch (cijenaRange)
            {
                case "0-200": artikli = artikli.Where(a => a.cijena >= 0 && a.cijena <= 200); break;
                case "200-500": artikli = artikli.Where(a => a.cijena > 200 && a.cijena <= 500); break;
                case "500-1000": artikli = artikli.Where(a => a.cijena > 500 && a.cijena <= 1000); break;
                case "1000+": artikli = artikli.Where(a => a.cijena > 1000); break;
            }
        }

        var lista = await artikli.ToListAsync();

        // Dohvati ocjene korisnika
        var userIds = lista.Select(a => a.UserId).Distinct().ToList();
        var emailMap = new Dictionary<string, string>();
        var ocjeneMap = new Dictionary<string, string>();
        var ocjeneMapDouble = new Dictionary<string, double>();

        foreach (var uid in userIds)
        {
            if (uid != null)
            {
                var user = await _userManager.FindByIdAsync(uid);
                if (user != null)
                    emailMap[uid] = user.Email;

                var prosjecna = await _context.Ocjena
                    .Where(o => o.ocjenjenId == uid)
                    .Select(o => (double?)o.vrijednost)
                    .AverageAsync();

                ocjeneMap[uid] = prosjecna.HasValue ? prosjecna.Value.ToString("0.0") : "N/A";
                ocjeneMapDouble[uid] = prosjecna ?? 0;
            }
        }

        // Sortiranje (in-memory based on computed maps)
        lista = sortiranje switch
        {
            "cijena_asc" => lista.OrderBy(a => a.cijena).ToList(),
            "cijena_desc" => lista.OrderByDescending(a => a.cijena).ToList(),
            "ocjena_desc" => lista.OrderByDescending(a => a.UserId != null && ocjeneMapDouble.ContainsKey(a.UserId) ? ocjeneMapDouble[a.UserId] : 0).ToList(),
            "ocjena_asc" => lista.OrderBy(a => a.UserId != null && ocjeneMapDouble.ContainsKey(a.UserId) ? ocjeneMapDouble[a.UserId] : 0).ToList(),
            _ => lista
        };

        ViewBag.EmailMap = emailMap;
        ViewBag.OcjeneMap = ocjeneMap;
        ViewBag.Pretraga = pretraga;
        ViewBag.Stanje = stanje;
        ViewBag.TipTransakcije = tipTransakcije;
        ViewBag.Sortiranje = sortiranje;
        ViewBag.CijenaRange = cijenaRange;
        return View(lista);
    }

    public async Task<IActionResult> GetEmail(string userId)
    {
        if (string.IsNullOrEmpty(userId))
            return Content("");

        var user = await _userManager.FindByIdAsync(userId);
        return Content(user?.Email ?? "");
    }
}