using Microsoft.AspNetCore.Mvc;
using Library.DATA;
using Library.Repository;
using Library.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
namespace Library.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBookRepository _bookRepository;
        private readonly LibraryDBContext _context;

        public BooksController(IBookRepository bookRepository, LibraryDBContext context)
        {
            _bookRepository = bookRepository;
            _context = context;
        }

        public IActionResult Index(int shelfId) // Add shelfId parameter
        {
        return View();
        }
        public IActionResult GetBooksByShelf(int shelfId)
        {
            var books = _context.Books
                .Include(b => b.Shelf)
                .Where(b => b.ShelfId == shelfId)
                .ToList();

            var shelfName = _context.Shelfs
                .Where(s => s.Id == shelfId)
                .Select(s => s.Name)
                .FirstOrDefault();
            ViewBag.ShelfName = shelfName;
            return View(books);
        }

        [HttpPost]
        public IActionResult AddBook(Book book)
        {
            _bookRepository.AddBook(book);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult UpdateBook(int id)
        {
            var book = _context.Books.Find(id);
            if (book == null)
            {
                return NotFound();
            }

            ViewBag.Shelves = _context.Shelfs.ToList();
            return View(book);
        }

        [HttpPost]
        public IActionResult UpdateBook(Book book)
        {
            if (ModelState.IsValid)
            {
                _bookRepository.UpdateBook(book);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Shelves = _context.Shelfs.ToList();
            return View(book);
        }

        [HttpGet]
        public IActionResult DeleteBook(int id)
        {
            var book = _context.Books.Find(id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        [HttpPost, ActionName("DeleteBook")]
        public IActionResult DeleteConfirmed(int id)
        {
            _bookRepository.DeleteBook(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
