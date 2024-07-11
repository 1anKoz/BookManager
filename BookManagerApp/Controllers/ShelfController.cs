using BookManagerApp.Data;
using BookManagerApp.Interfaces;
using BookManagerApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookManagerApp.Controllers
{
    public class ShelfController : Controller
    {
        private readonly IShelfRepository _shelfRepository;
        public ShelfController(IShelfRepository shelfRepository)
        {
                _shelfRepository = shelfRepository;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Shelf> shelves = await _shelfRepository.GetAll();
            //List<Shelf> shelves = _context.Shelves.Include(b => b.Books).ToList();
            return View(shelves);
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}
