using Library.DATA;
using Library.Models;
using Library.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    public class ShelfesController : Controller
    {
        private readonly LibraryDBContext _context;
        private readonly IShelfRepository _shelfRepo;

        public ShelfesController(LibraryDBContext context, IShelfRepository shelfRepo)
        {
            _context = context;
            _shelfRepo = shelfRepo;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var Shelfes = _shelfRepo.GetShelfs(0).ToList();
            return View(Shelfes);
        }
        public IActionResult BooksInShelf(int id)
        {
            var books = _context.Books.Where(b => b.ShelfId == id).ToList();
            return PartialView("_BooksPartial", books);
        }
        [HttpGet]
        public IActionResult CreateShelf()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateShelf(Shelf shelf)
        {
                _context.Shelfs.Add(shelf);
                _context.SaveChanges();
                return RedirectToAction("Index");
        }
        public IActionResult UpDateShelf(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var shelf = _context.Shelfs.Find(id);
            if (shelf == null)
            {
                return NotFound();
            }

            return View(shelf);
        }
        // POST: Shelfes/Edit/5
        [HttpPost]
        public IActionResult UpDateShelf(int id, Shelf shelf)
        {
            if (id != shelf.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _context.Update(shelf);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(shelf);
        }
        [HttpGet]
        public IActionResult DeleteShelf(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var shelf = _context.Shelfs.Find(id);
            if (shelf == null)
            {
                return NotFound();
            }
            return View(shelf);
        }
        [HttpPost]
        [ActionName("DeleteShelf")]
        public IActionResult DeleteConfirmed(int id)
        {
            var shelf = _context.Shelfs.Find(id);
            _context.Shelfs.Remove(shelf);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
