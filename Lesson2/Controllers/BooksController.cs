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
    
    // POST: /Books/Orders
    [HttpPost]
    public async Task<IActionResult> Order(int bookId, int quantity = 1)
    {
        var book = await _db.Books.FindAsync(bookId);
        if (book == null)
        {
            TempData["ErrorMessage"] = "Book not found";
            return RedirectToAction("Index");
        }
        
        // hard code
        const int userId = 1;
        
        var order = new Order
        {
            UserId = userId,
            BookId = bookId,
            Quantity = quantity,
            TotalPrice = book.Price * quantity,
            OrderDate = DateTime.Now
        };
        
        _db.Orders.Add(order);
        await _db.SaveChangesAsync();
        
        TempData["SuccessMessage"] = "Order placed successfully!";
        return RedirectToAction("Index");
    }
}