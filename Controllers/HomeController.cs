using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MyPets.Models;
using MyPets.Data;

namespace MyPets.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _context;

        public HomeController(ILogger<HomeController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Gallery()
        {
            var pets = _context.PetAdopts.ToList();
            return View(pets);
        }



        public IActionResult Services(ServiceBooking booking)
        {

            var services = new List<string>
            {
                 "Pet Grooming",
                 "Dog Walking",
                 "Pet Bath",
                 "Training",
                 "Vet Checkup"
            };

            var random3 = services
                .OrderBy(x => Guid.NewGuid())
                .Take(3)
                .ToList();

            ViewBag.Services = random3;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Book(ServiceBooking booking)
        {

            if (!ModelState.IsValid)
                return View("Services");

            _context.ServiceBookings.Add(booking);
            _context.SaveChanges();

            TempData["Success"] = "Your service request has been sent!";

            return RedirectToAction("Services");

        }

        public IActionResult PetShop()
        {


            var product = _context.Products.ToList();
            return View(product);
        }



        public IActionResult About()
        {
            var vm = new FeedbackVM();

            vm.ListData = _context.FeedBacks.ToList();

            return View(vm);
        }
        public IActionResult Contact()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
