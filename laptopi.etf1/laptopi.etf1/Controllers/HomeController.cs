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

    public async Task<IActionResult> Index(string? pretraga, string? stanje)
    {
        var artikli = _context.Artikal.AsQueryable();

        if (!string.IsNullOrEmpty(pretraga))
        {
            artikli = artikli.Where(a => a.naziv.Contains(pretraga) || a.opis.Contains(pretraga));
        }

        if (stanje == "Novo")
        {
            artikli = artikli.Where(a => a.stranje == Stanje.Novo);
        }
        else if (stanje == "Polovno")
        {
            artikli = artikli.Where(a => a.stranje == Stanje.Polovno);
        }

        var lista = await artikli.ToListAsync();

        var userIds = lista.Select(a => a.UserId).Distinct().ToList();
        var emailMap = new Dictionary<string, string>();

        foreach (var uid in userIds)
        {
            if (uid != null)
            {
                var user = await _userManager.FindByIdAsync(uid);
                if (user != null)
                    emailMap[uid] = user.Email;
            }
        }

        ViewBag.EmailMap = emailMap;
        ViewBag.Pretraga = pretraga;
        ViewBag.Stanje = stanje;
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