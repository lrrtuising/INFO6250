using Microsoft.AspNetCore.Mvc;
using Lesson2.Models;
using Lesson2.ApplicationDB;
using Microsoft.EntityFrameworkCore;

namespace Lesson2.Controllers;

public class OrdersController : Controller
{
    private readonly ApplicationDBContext _db;
    
    public OrdersController(ApplicationDBContext db)
    {
        _db = db;
    }
    
    public async Task<IActionResult> Index()
    {
        const int userId = 1;

        var orders = await _db.Orders
            .Include(o => o.Book)
            .Include(o => o.User)
            .Where(o => o.UserId == userId)
            .OrderByDescending(o => o.OrderDate)
            .ToListAsync();

        return View(orders);
    }
}
