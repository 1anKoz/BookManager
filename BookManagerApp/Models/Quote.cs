using System.ComponentModel.DataAnnotations;

namespace BookManagerApp.Models
{
    public class Quote
    {
        [Key]
        public int Id { get; set; }
        public string? Content { get; set; }
        public int Page { get; set; }
        public bool IsFavourite { get; set; }

        public int BookId { get; set; }
        public virtual Book? Book { get; set; }
    }
}
