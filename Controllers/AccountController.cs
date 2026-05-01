using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using MyPets.Data;
using MyPets.Models;
using System.Linq;

namespace MyPets.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext _context;

        public AccountController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Login(AdminLogin model)
        {

            try
            {
                var admin = _context.AdminLogins
                    .FirstOrDefault(a => a.Email == model.Email && a.Password == model.Password);

                if (admin != null)
                {
                    HttpContext.Session.SetString("AdminEmail", admin.Email);
                    return RedirectToAction("Deshboard", "Admin");
                }

                return Content("Invalid Login");
            }
            catch (Exception ex)
            {
                return Content("ERROR: " + ex.Message);
            }

        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
