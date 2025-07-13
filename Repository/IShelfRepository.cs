using Library.Models;

namespace Library.Repository
{
    public interface IShelfRepository
    {
       public IQueryable<Shelf> GetShelfs(int shelfId );
        public IEnumerable<Shelf> GetListShelf();
       
        void UpdateShelf(Shelf shelf);
        public void DeleteShelf(int shelfId);
        public void AddShelf(Shelf shelf);
    }
}
