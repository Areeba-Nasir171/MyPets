using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyPets.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MyPets.Controllers
{
    public class AdminServiceController : Controller
    {
        private readonly AppDbContext _context;

        public AdminServiceController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Requests()
        {
            var data = _context.ServiceBookings.ToList();
            return View(data);
        }

        public IActionResult Approve(int id)
        {
            var req = _context.ServiceBookings.Find(id);
            if (req != null)
            {
                req.Status = "Approved";
                _context.SaveChanges();
            }

            return RedirectToAction("Requests");
        }

        public IActionResult Reject(int id)
        {
            var req = _context.ServiceBookings.Find(id);
            if (req != null)
            {
                req.Status = "Rejected";
                _context.SaveChanges();
            }

            return RedirectToAction("Requests");
        }

    }
}
