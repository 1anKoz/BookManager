using BookManagerApp.Models;

namespace BookManagerApp.Interfaces
{
    public interface IShelfRepository
    {
        Task<IEnumerable<Shelf>> GetAll();
        Task<Shelf> GetByIdAsync(int id);
        Task<Shelf> GetByIdAsyncNoTracking(int id);

        bool Add(Shelf shelf);
        bool Update(Shelf shelf);
        bool Delete(Shelf shelf);
        bool Save();
    }
}
