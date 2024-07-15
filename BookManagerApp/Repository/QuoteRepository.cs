using BookManagerApp.Data;
using BookManagerApp.Interfaces;
using BookManagerApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BookManagerApp.Repository
{
    public class QuoteRepository : IQuoteRepository
    {
        private readonly ApplicationDbContext _context;

        public QuoteRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Add(Quote quote)
        {
            _context.Add(quote);
            return Save();
        }

        public bool Delete(Quote quote)
        {
            _context.Remove(quote);
            return Save();
        }

        public async Task<IEnumerable<Quote>> GetAllAsync()
        {
            return await _context.Quotes.ToListAsync();
        }

        public async Task<Quote> GetByIdAsync(int id)
        {
            return await _context.Quotes.FirstOrDefaultAsync(i => i.Id == id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(Quote quote)
        {
            _context.Update(quote);
            return Save();
        }
    }
}
