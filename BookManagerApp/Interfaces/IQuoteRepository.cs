using BookManagerApp.Models;

namespace BookManagerApp.Interfaces
{
    public interface IQuoteRepository
    {
        Task<IEnumerable<Quote>> GetAllAsync();
        Task<Quote> GetByIdAsync(int id);
        bool Add(Quote quote);
        bool Update(Quote quote);
        bool Delete(Quote quote);
        bool Save();
    }
}
