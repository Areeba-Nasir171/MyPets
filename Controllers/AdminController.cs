using Microsoft.AspNetCore.Mvc;
using MyPets.Data;
using MyPets.Models;
using System.Linq;

namespace MyPets.Controllers
{
    public class AdminController : Controller
    {
        private readonly AppDbContext _context;

        public AdminController(AppDbContext context)

        {
            _context = context;

        }
        public IActionResult Deshboard()
        {
            var adminSession = HttpContext.Session.GetString("AdminEmail");
            if (adminSession == null)
            {
                return RedirectToAction("Login", "Account");

            }

            return View();
        }














    }
}
