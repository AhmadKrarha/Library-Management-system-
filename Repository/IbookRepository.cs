using Library.Models;
using Microsoft.EntityFrameworkCore;
namespace Library.Repository
{
    public interface IBookRepository
    {
        Book GetBookByName(string BookName);
        public IQueryable<Book> GetBooksByShelfId(int shelfId);

        void AddBook(Book book);
        void UpdateBook(Book book);
        void DeleteBook(int Id);
    }
}
















