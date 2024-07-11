using BookManagerApp.Data;
using BookManagerApp.Interfaces;
using BookManagerApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookManagerApp.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookRepository _bookRepository;
        public BookController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<IActionResult> Detail(int id)
        {
            Book book = await _bookRepository.GetByIdAsync(id);
            return View(book);
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}
