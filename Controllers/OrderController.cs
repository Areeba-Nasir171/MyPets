using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyPets.Data;
using MyPets.Models;

namespace MyPets.Controllers
{
    public class OrderController : Controller
    {
        private readonly AppDbContext _context;

        public OrderController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var orders = _context.Orders
     .Include(o => o.Product)
     .ToList();

            return View(orders);

        }

        public IActionResult ByNow(int Id)
        {
            var product = _context.Products.FirstOrDefault(x => x.Id == Id);

            if (product == null)
                return NotFound();

            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult PlaceOrder(Order order)
        {


            if (!ModelState.IsValid)
            {
                var product = _context.Products
                    .FirstOrDefault(p => p.Id == order.ProductId);

                return View("ByNow", product);
            }

            order.Status = "Pending";
            order.OrderDate = DateTime.Now;

            _context.Orders.Add(order);
            _context.SaveChanges();


            TempData["Success"] = "Order placed successfully!";

            return RedirectToAction("ByNow", new { id = order.ProductId });
        }


        public IActionResult ToggleStatus(int id)
        {
            var order = _context.Orders.FirstOrDefault(x => x.OrderId == id);

            if (order != null)
            {
                if (order.Status == "Pending")
                    order.Status = "Delivered";
                else
                    order.Status = "Pending";

                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var order = _context.Orders.FirstOrDefault(x => x.OrderId == id);

            if (order != null)
            {
                _context.Orders.Remove(order);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }


    }
}
