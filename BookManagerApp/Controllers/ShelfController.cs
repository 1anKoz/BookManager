using BookManagerApp.Data;
using BookManagerApp.Interfaces;
using BookManagerApp.Models;
using BookManagerApp.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
            IEnumerable<Shelf> shelves = await _shelfRepository.GetAllAsync();
            //List<Shelf> shelves = _context.Shelves.Include(b => b.Books).ToList();
            return View(shelves);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Shelf shelf)
        {
            if (!ModelState.IsValid)
            {
                return View(shelf);
            }
            _shelfRepository.Add(shelf);
            return RedirectToAction("Index", "Shelf");
        }
    }
}
