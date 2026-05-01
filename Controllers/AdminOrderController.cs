using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyPets.Data;

namespace MyPets.Controllers
{
    public class AdminOrderController : Controller
    {
        private readonly AppDbContext _context;

        public AdminOrderController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {

            var orders = _context.Orders.Include(o => o.Product).ToList();


            return View(orders);
        }
    }
}
