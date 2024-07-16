using BookManagerApp.Data;
using BookManagerApp.Interfaces;
using BookManagerApp.Models;
using BookManagerApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookManagerApp.Controllers
{
    public class ShelfController : Controller
    {
        private readonly IShelfRepository _shelfRepository;
        private readonly IPhotoService _photoService;

        public ShelfController(IShelfRepository shelfRepository, IPhotoService photoService)
        {
            _shelfRepository = shelfRepository;
            _photoService = photoService;
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

        [HttpPost]
        public async Task<IActionResult> Create(CreateShelfViewModel shelfVM)
        {
            if (ModelState.IsValid)
            {
                var result = await _photoService.AddPhotoAsync(shelfVM.Icon);

                var shelf = new Shelf
                {
                    Name = shelfVM.Name,
                    Description = shelfVM.Description,
                    Icon = result.Url.ToString()
                };
                _shelfRepository.Add(shelf);
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Photo upload failed");
            }

            return View(shelfVM);
        }
    }
}
