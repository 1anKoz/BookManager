using BookManagerApp.Data.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookManagerApp.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? CoverUrl { get; set; }
        public string? Description { get; set; }
        public BookGenre Genre { get; set; }
        public string? Author { get; set; }
        public string? Isbn { get; set; }
        public string? UserDescription { get; set; }
        public int Score { get; set; }
        public bool IsBeingRead { get; set; }
        public bool IsFavourite { get; set; }
        public DateTime StartedAt { get; set; }
        public DateTime FinishedAt { get; set; }

        public Shelf? Shelf { get; set; }

        ////[ForeignKey("Quote")]
        //public ICollection<Quote>? Quotes { get; set; }
    }
}
