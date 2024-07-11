using BookManagerApp.Models;

namespace BookManagerApp.Interfaces
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetAll();
        Task<Book> GetByIdAsync(int id);
        Task<IEnumerable<Book>> GetBooksByBeingRead(bool isBeingRead);
        bool Add(Book book);
        bool Update(Book book);
        bool Delete(Book book);
        bool Save();
    }
}
