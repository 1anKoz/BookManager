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
                var result = await _photoService.AddPhotoAsync(shelfVM.IconImg);

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

        public async Task<IActionResult> Edit(int id)
        {
            var shelf = await _shelfRepository.GetByIdAsync(id);
            if (shelf == null) return View("Error");
            var shelfVM = new EditShelfViewModel
            {
                Name= shelf.Name,
                Description= shelf.Description,
                IconUrl = shelf.Icon,
            };
            return View(shelfVM);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditShelfViewModel shelfVM)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Failed to edit shelf");
                return View("Edit", shelfVM);
            }
            var userShelf = await _shelfRepository.GetByIdAsyncNoTracking(id);

            if (userShelf != null)
            {
                try
                {
                    await _photoService.DeletePhotoAsync(userShelf.Icon);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Could not delete the icon photo");
                    return View(shelfVM);
                }
                var photoResult = await _photoService.AddPhotoAsync(shelfVM.IconImg);

                var shelf = new Shelf
                {
                    Id = id,
                    Name = shelfVM.Name,
                    Description = shelfVM.Description,
                    Icon = photoResult.Url.ToString()
                };

                _shelfRepository.Update(shelf);

                return RedirectToAction("Index");
            }
            else
            {
                return View(shelfVM);
            }

        }
    }
}
