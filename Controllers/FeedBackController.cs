using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.IO;
using MyPets.Data;
using MyPets.Models;


namespace MyPets.Controllers
{
    public class FeedBackController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        public FeedBackController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }


        public IActionResult Index()
        {
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Save(FeedbackVM vm, IFormFile Image)
        {
            var model = vm.FormData;

            if (!ModelState.IsValid)
            {
                var errors = ModelState
      .Where(x => x.Value.Errors.Count > 0)
      .Select(x => $"{x.Key}: {string.Join(",", x.Value.Errors.Select(e => e.ErrorMessage))}")
      .ToList();

                return Content(string.Join(" | ", errors));
            }

            if (Image != null && Image.Length > 0)
            {
                string fileName = Guid.NewGuid() + Path.GetExtension(Image.FileName);

                string folderPath = Path.Combine(_env.WebRootPath, "Image", "Feedback");

                if (!Directory.Exists(folderPath))
                    Directory.CreateDirectory(folderPath);

                string fullPath = Path.Combine(folderPath, fileName);

                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    Image.CopyTo(stream);
                }

                model.ImagePath = "Feedback/" + fileName;
            }
            else
            {
                model.ImagePath = "default.png"; 
            }

            model.CreatedAt = DateTime.Now;
            model.IsApproved = false;

            _context.FeedBacks.Add(model);
            _context.SaveChanges();

            return RedirectToAction("About", "Home");
        }
    }
}
