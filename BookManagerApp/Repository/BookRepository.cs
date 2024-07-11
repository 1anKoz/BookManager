
using BookManagerApp.Data;
using BookManagerApp.Interfaces;
using BookManagerApp.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace BookManagerApp.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly ApplicationDbContext _context;
        public BookRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Add(Book book)
        {
            _context.Add(book);
            return Save();
        }

        public bool Delete(Book book)
        {
            _context.Remove(book);
            return Save();
        }

        public async Task<IEnumerable<Book>> GetAll()
        {
            return await _context.Books.ToListAsync();
        }

        public async Task<IEnumerable<Book>> GetBooksByBeingRead(bool isBeingRead)
        {
            return await _context.Books.Where(b => b.IsBeingRead).ToListAsync();
        }

        public async Task<Book> GetByIdAsync(int id)
        {
            return await _context.Books.Include(q => q.Quotes).FirstOrDefaultAsync(i => i.Id == id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(Book book)
        {
            _context.Update(book);
            return Save();
        }
    }
}
