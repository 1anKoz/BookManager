using BookManagerApp.Data;
using BookManagerApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookManagerApp.Controllers
{
    public class ShelfController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ShelfController(ApplicationDbContext context)
        {
                _context = context;
        }

        public IActionResult Index()
        {
            List<Shelf> shelves = _context.Shelves.Include(b => b.Books).ToList();
            return View(shelves);
        }
    }
}
