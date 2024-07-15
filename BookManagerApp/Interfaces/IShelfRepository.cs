using BookManagerApp.Models;

namespace BookManagerApp.Interfaces
{
    public interface IShelfRepository
    {
        Task<IEnumerable<Shelf>> GetAllAsync();
        Task<Shelf> GetByIdAsync(int id);

        bool Add(Shelf shelf);
        bool Update(Shelf shelf);
        bool Delete(Shelf shelf);
        bool Save();
    }
}
