namespace BookManagerApp.Models
{
    public class User
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string NickName { get; set; }
        public string? PhotoUrl { get; set; }
        public string Password { get; set; }

        public virtual List<Shelf>? Shelves { get; set; }
        public virtual List<Book>? Books { get; set; }
        public virtual List<Quote>? Quotes { get; set; }
    }
}