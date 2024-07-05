using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookManagerApp.Models
{
    public class Shelf
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public virtual List<Book>? Books { get; set; }
    }
}
