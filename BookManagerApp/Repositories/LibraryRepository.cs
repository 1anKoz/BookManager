using BookManagerApp.Data;
using BookManagerApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace BookManagerApp.Repositories
{
    public class LibraryRepository
    {
        private readonly ApplicationDbContext _context;

        public LibraryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Shelf> GetShelves()
        {
            return _context.Shelves.ToList();
        }

        public IEnumerable<Book> GetBooks()
        {
            return _context.Books.ToList();
        }
    }
}