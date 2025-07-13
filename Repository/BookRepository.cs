using Library.DATA;
using Library.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Library.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly LibraryDBContext _context;
        public BookRepository(LibraryDBContext context) => _context = context;

        public Book GetBookByName(string BookName) => _context.Books.FirstOrDefault(b => b.Title.Contains(BookName));
        public IQueryable<Book> GetBooksByShelfId(int shelfId)
        {
            return _context.Books.Where(b => b.ShelfId == shelfId);
        }
        public void AddBook(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
        }
        
        public void UpdateBook(Book book)
        {
            _context.Books.Update(book);
               _context.SaveChanges();
        }
        public void DeleteBook(int Id)
        {
            var book = _context.Books.Find(Id); 
            _context.Books.Remove(book);
                    _context.SaveChanges();
        }

    }
}

















