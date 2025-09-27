using Lesson2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Lesson2.ApplicationDB;

namespace Lesson2.Controllers;

public class BooksController : Controller
{
    private ApplicationDBContext _db;
    
    public BooksController(ApplicationDBContext db)
    {
        _db = db;
    }
    
    // GET: /Books/
    public async Task<IActionResult> Index()
    {
        var books = await _db.Books.ToListAsync();
        return View(books);
    }
    
    // GET: /Books/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }
        var book = await _db.Books.FirstOrDefaultAsync(b => b.Id == id);
        
        if (book == null)
        {
            return NotFound();
        }
        return View(book);
    }
}