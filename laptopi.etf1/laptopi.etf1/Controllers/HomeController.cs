using laptopi.etf1.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace laptopi.etf1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var artikli = await _context.Artikal
                .Where(a => a.aktivnost == true)
                .Include(a => a.Slike)
                .ToListAsync();

            return View(artikli);
        }
    }
}
