using BookManagerApp.Data;
using BookManagerApp.Models;
using BookManagerApp.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BookManagerApp.Controllers
{
    public class LibraryViewModelController : Controller
    {
        private readonly LibraryRepository _repository;

        public LibraryViewModelController(LibraryRepository repository)
        {
            _repository = repository;
        }
        public IActionResult Index()
        {
            LibraryViewModel libraryViewModel = new LibraryViewModel
            {
                Shelves = _repository.GetShelves(),
                Books = _repository.GetBooks(),
            };

            return View(libraryViewModel);
        }
    }
}
