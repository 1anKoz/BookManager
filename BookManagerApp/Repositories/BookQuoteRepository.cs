using BookManagerApp.Data;
using BookManagerApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BookManagerApp.Repositories
{
    public class BookQuoteRepository
    {
        private readonly ApplicationDbContext _context;

        public BookQuoteRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public Book GetBook(int id)
        {
            return _context.Books.Include(q => q.Quotes).FirstOrDefault(c => c.Id == id);
        }

        public IEnumerable<Quote> GetQuotes()
        {
            return _context.Quotes.ToList();
        }
    }
}
