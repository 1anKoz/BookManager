using BookManagerApp.Data;
using BookManagerApp.Models;
using Microsoft.AspNetCore.Mvc;

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
            List<Shelf> shelves = _context.Shelves.ToList();
            return View(shelves);
        }
    }
}
