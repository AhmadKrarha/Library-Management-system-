using Library.DATA;
using Microsoft.EntityFrameworkCore;

namespace Library.Models
{
    public static class BookSeedData
    {
        public static void EnsureBooksPopulated(IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<LibraryDBContext>();

                if (context.Database.GetPendingMigrations().Any())
                {
                    context.Database.Migrate();
                }

                if (!context.Books.Any())
                {
                    context.Books.AddRange(
                        new Book
                        { 
                            Title = "Circuits",
                            ShelfId = 1
                        },
                        new Book
                        {
            
                            Title = "calculas 102",
                            ShelfId = 1
                        },
                        new Book
                        {
                 
                            Title = "Sofware engineering",
                            ShelfId = 1
                        },
                        new Book
                        {
                 
                            Title = "chemistry",
                            ShelfId = 2
                        },
                          new Book
                          {
                       
                              Title = "Physics",
                              ShelfId = 2
                          },
                            new Book
                            {
                             
                                Title = "pyology",
                                ShelfId = 2
                            }
                    );
                    context.SaveChanges();
                }
            }
        }
    }
}
