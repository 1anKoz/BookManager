using System.ComponentModel.DataAnnotations;

namespace BookManagerApp.Models
{
    public class Quote
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Content is required")]
        public string? Content { get; set; }
        [Required(ErrorMessage = "You have to specify the page")]
        public int Page { get; set; }
        public bool IsFavourite { get; set; }

        public int BookId { get; set; }
        public virtual Book? Book { get; set; }
    }
}
