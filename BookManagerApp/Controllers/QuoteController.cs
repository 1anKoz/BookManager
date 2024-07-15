using BookManagerApp.Interfaces;
using BookManagerApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookManagerApp.Controllers
{
    public class QuoteController : Controller
    {
        private readonly IQuoteRepository _quoteRepository;
        private readonly IBookRepository _bookRepository;

        public QuoteController(IQuoteRepository quoteRepository, IBookRepository bookRepository)
        {
            _quoteRepository = quoteRepository;
            _bookRepository = bookRepository;
        }

        public async Task<IActionResult> Create(int? bookId)
        {
            var books = await _bookRepository.GetAll();
            ViewBag.Books = new SelectList(books, "Id", "Title");

            ViewBag.BookId = bookId ?? 0;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Quote quote, int? bookId)
        {
            if (!ModelState.IsValid)
            {
                var books = await _bookRepository.GetAll();
                ViewBag.Books = new SelectList(books, "Id", "Title");

                return View(quote);
            }

            quote.BookId = bookId ?? quote.BookId; // Ensure BookId is set
            _quoteRepository.Add(quote);
            return RedirectToAction("Detail", "Book", new { id = quote.BookId });
        }
    }
}
