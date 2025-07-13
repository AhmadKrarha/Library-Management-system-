using System.Collections.Generic;
using Library.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.DATA
{
    public class LibraryDBContext : DbContext
    {
        internal readonly object Shelfes;

        public LibraryDBContext()
        {
        }

        public LibraryDBContext(DbContextOptions<LibraryDBContext> options)
            : base(options)
        {
        }

        public DbSet<Shelf> Shelfs { get; set; }
        public DbSet<Book> Books { get; set; }
        public object Shelves { get; internal set; }
    }
}
