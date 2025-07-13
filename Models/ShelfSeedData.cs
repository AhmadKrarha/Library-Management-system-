using Library.DATA;
using Library.Models;
using Microsoft.EntityFrameworkCore;

public static class ShelfSeedData
{
    public static void EnsureShelvesPopulated(IApplicationBuilder app)
    {
        using (var scope = app.ApplicationServices.CreateScope())
        {
            var context = scope.ServiceProvider.GetRequiredService<LibraryDBContext>();

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            if (!context.Shelfs.Any())
            {
                context.Shelfs.AddRange(
                    new Shelf
                    {
           
                        Name = "Engineering"
                    },
                    new Shelf
                    {

                        Name = "Scince"
                    },
                    new Shelf
                    {

                        Name = "Math"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
