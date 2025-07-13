using System.Linq;
using Library.DATA;
using Library.Models;

namespace Library.Repository
{
    public class ShelfRepository : IShelfRepository
    {
        private LibraryDBContext _context;

        public ShelfRepository(LibraryDBContext ctx) => _context = ctx;

        public IQueryable<Shelf> shelfs => _context.Shelfs;

        public IQueryable<Shelf> GetShelfs(int shelfId)
        {
            return _context.Shelfs.Where(s => s.Id == shelfId);
        }

        public void UpdateShelf(Shelf shelf)
        {
            _context.Shelfs.Update(shelf);
            _context.SaveChanges();
        }

        public void DeleteShelf(int shelfId)
        {
            var shelf = _context.Shelfs.Find(shelfId);
            if (shelf != null)
            {
                _context.Shelfs.Remove(shelf);
                _context.SaveChanges();
            }
        }

        public void AddShelf(Shelf shelf)
        {
            _context.Shelfs.Add(shelf);
            _context.SaveChanges();
        }
        public IEnumerable<Shelf> GetListShelf()
        {
           return _context.Shelfs.ToList();
        }
    }
}

