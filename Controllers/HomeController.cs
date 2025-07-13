using Library.DATA;
using Library.Models;
using Library.Repository;
using Microsoft.AspNetCore.Mvc;

public class HomeController : Controller
{
    private readonly LibraryDBContext _context;
    private readonly IShelfRepository repostry;

    public HomeController(LibraryDBContext context, ShelfRepository repo)
    {
        _context = context;
        repostry = repo;
    }

    public IActionResult Index()
    {
        var shelfs = _context.Shelfs.ToList();
        return View(shelfs);
    }
}
