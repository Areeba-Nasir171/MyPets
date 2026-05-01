using Microsoft.AspNetCore.Mvc;
using MyPets.Data;

namespace MyPets.Controllers
{

    public class AdminFeedBackController : Controller
    {

        private readonly AppDbContext _context;

        public AdminFeedBackController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public ActionResult Feedbacks()
        {
            var data = _context.FeedBacks.ToList();
            return View(data);
        }


        public IActionResult Approve(int id)
        {
            var data = _context.FeedBacks.Find(id);

            if (data != null)
            {
                data.IsApproved = true;
                _context.SaveChanges();
            }

            return RedirectToAction("Feedbacks");
        }

        public ActionResult Delete(int id)
        {
            var fb = _context.FeedBacks.Find(id);
            _context.FeedBacks.Remove(fb);
            _context.SaveChanges();

            return RedirectToAction("FeedBacks");
        }
    }
}
