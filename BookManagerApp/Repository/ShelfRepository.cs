using BookManagerApp.Data;
using BookManagerApp.Interfaces;
using BookManagerApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BookManagerApp.Repository
{
    public class ShelfRepository : IShelfRepository
    {
        private readonly ApplicationDbContext _context;
        public ShelfRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool Add(Shelf shelf)
        {
            _context.Add(shelf);
            return Save();
        }

        public bool Delete(Shelf shelf)
        {
            _context.Remove(shelf);
            return Save();
        }

        public async Task<IEnumerable<Shelf>> GetAll()
        {
            return await _context.Shelves.Include(b => b.Books).ToListAsync();
        }

        public async Task<Shelf> GetByIdAsync(int id)
        {
            return await _context.Shelves.FirstOrDefaultAsync(i => i.Id == id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(Shelf shelf)
        {
            _context.Update(shelf);
            return Save();
        }
    }
}
