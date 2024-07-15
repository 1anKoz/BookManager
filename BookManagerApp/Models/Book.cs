using BookManagerApp.Data.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookManagerApp.Models
{
    public class Book
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Title is required")]
        public string? Title { get; set; }
        [Required(ErrorMessage = "Cover image URL is required")]
        public string? CoverUrl { get; set; }
        public string? Description { get; set; }
        public BookGenre Genre { get; set; }
        [Required(ErrorMessage = "Author is required")]
        public string? Author { get; set; }
        public string? Isbn { get; set; }
        public string? UserDescription { get; set; }
        public int Score { get; set; }
        public bool IsBeingRead { get; set; }
        public bool IsFavourite { get; set; }
        public DateTime StartedAt { get; set; }
        public DateTime FinishedAt { get; set; }

        [Required(ErrorMessage = "You must specify ShelfId")]
        public int ShelfId { get; set; }
        public virtual Shelf? Shelf { get; set; }

        public virtual List<Quote>? Quotes { get; set; }
    }
}
