using BookManagerApp.Data;
using BookManagerApp.Interfaces;
using BookManagerApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BookManagerApp.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookRepository _bookRepository;
        private readonly IShelfRepository _shelfRepository;
        public BookController(IBookRepository bookRepository, IShelfRepository shelfRepository)
        {
            _bookRepository = bookRepository;
            _shelfRepository = shelfRepository;
        }

        public async Task<IActionResult> Detail(int id)
        {
            Book book = await _bookRepository.GetByIdAsync(id);
            return View(book);
        }

        public async Task<IActionResult> Create()
        {
            var shelves = await _shelfRepository.GetAllAsync();
            ViewBag.Shelves = new SelectList(shelves, "Id", "Name");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Book book)
        {
            if (!ModelState.IsValid)
            {
                var shelves = await _shelfRepository.GetAllAsync();
                ViewBag.Shelves = new SelectList(shelves, "Id", "Name");

                return View(book);
            }
            _bookRepository.Add(book);
            return RedirectToAction("Index", "Shelf");
        }
    }
}
