using System.Collections.Generic; 
namespace Library.Models
{
    public class Shelf
    {

        public int Id { get; set; }
        public string? Name { get; set; } = String.Empty;
        public List<Book> Books { get; set; } = [];
    }
}
