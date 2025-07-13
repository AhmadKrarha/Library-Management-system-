using System.ComponentModel.DataAnnotations;
namespace Library.Models
{
    public class Book
    {
        [Required]
        public int Id { get; set; }
        public string? Title { get; set; } = string.Empty;
        [Required]
        public int ShelfId { get; set; }
        public Shelf? Shelf { get; set; }
    }
}