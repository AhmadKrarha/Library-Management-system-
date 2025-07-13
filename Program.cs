using Library.DATA;
using Library.Models;
using Library.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<LibraryDBContext>(options =>options.UseSqlServer(builder.Configuration.GetConnectionString("Defaultconnection")));
builder.Services.AddScoped<Library.Repository.ShelfRepository>();
builder.Services.AddScoped<IShelfRepository, ShelfRepository>();
builder.Services.AddScoped<IBookRepository, BookRepository>();

var app = builder.Build();

ShelfSeedData.EnsureShelvesPopulated(app);
BookSeedData.EnsureBooksPopulated(app);
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapDefaultControllerRoute();

app.Run();
