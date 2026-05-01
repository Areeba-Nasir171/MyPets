using Microsoft.AspNetCore.Mvc;
using MyPets.Data;
using MyPets.Models;

public class ProductsController : Controller
{
    private readonly AppDbContext _context;
    private readonly IWebHostEnvironment _env;

    public ProductsController(AppDbContext context, IWebHostEnvironment env)
    {
        _context = context;
        _env = env;
    }


    public IActionResult Index()
    {

        try
        {
            var product = _context.Products.ToList();
            return View(product);
        }
        catch (Exception ex)
        {
            return Content("Error: " + ex.Message);
        }
    }


    public IActionResult Create()
    {

        return View();
    }


    [HttpPost]
    public IActionResult Create(Product p)
    {
        if (ModelState.IsValid)
        {

            string fileName = Guid.NewGuid() + Path.GetExtension(p.ImageFile.FileName);
            string path = Path.Combine(_env.WebRootPath, "image", fileName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                p.ImageFile.CopyTo(stream);
            }

            p.ImageUrl = "/image/" + fileName;

            _context.Products.Add(p);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        return View(p);
    }


    public IActionResult Edit(int id)
    {

        var data = _context.Products.Find(id);
        return View(data);
    }


    [HttpPost]
    public IActionResult Edit(Product p)
    {
        if (ModelState.IsValid)
        {
            var existing = _context.Products.Find(p.Id);
            if (existing == null) return NotFound();

            existing.Name = p.Name;
            existing.Category = p.Category;
            existing.Price = p.Price;
            existing.Description = p.Description;


            if (p.ImageFile != null)
            {
                string fileName = Guid.NewGuid() + Path.GetExtension(p.ImageFile.FileName);
                string path = Path.Combine(_env.WebRootPath, "images", fileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    p.ImageFile.CopyTo(stream);
                }

                existing.ImageUrl = "/images/" + fileName;
            }

            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(p);
    }


    public IActionResult Delete(int id)
    {
        var data = _context.Products.Find(id);
        _context.Products.Remove(data);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }
}