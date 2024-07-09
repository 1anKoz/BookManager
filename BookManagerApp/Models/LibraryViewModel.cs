namespace BookManagerApp.Models
{
    public class LibraryViewModel
    {
        public IEnumerable<Shelf> Shelves { get; set; }
        public IEnumerable<Book> Books { get; set; }
    }
}
