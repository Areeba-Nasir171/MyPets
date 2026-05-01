using Microsoft.AspNetCore.Mvc;
using MyPets.Data;
using MyPets.Migrations;
using MyPets.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MyPets.Controllers
{
    public class PetAdoptedController : Controller

    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public PetAdoptedController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index()
        {
            try
            {
                var pets = _context.PetAdopts.ToList();
                return View(pets);
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
        public IActionResult Create(PetAdopt model)
        {

            string fileName = null;
            if (model.ImgFile != null)
            {
                fileName = Path.GetFileName(model.ImgFile.FileName);

                string path = Path.Combine(_env.WebRootPath, "image/petadopt", fileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    model.ImgFile.CopyTo(stream);
                }

                model.ImageUrl = fileName;
            }





            PetAdopt pet = new PetAdopt
            {
                PetName = model.PetName,
                Status = model.Status,
                ImageUrl = "image/petadopt/" + fileName
            };


            _context.PetAdopts.Add(pet);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Edite(int id)
        {
            var petAdopt = _context.PetAdopts.Find(id);
            return View(petAdopt);
        }

        [HttpPost]

        public IActionResult Edite(PetAdopt model)
        {
            var pet = _context.PetAdopts.FirstOrDefault(x => x.Id == model.Id);

            if (pet == null)
            {
                return NotFound("Pet not found");
            }

            if (pet == null) return NotFound();

            pet.PetName = model.PetName;
            pet.Status = model.Status;

            if (model.ImgFile != null)
            {
                string fileName = Guid.NewGuid() + Path.GetExtension(model.ImgFile.FileName);

                string path = Path.Combine(_env.WebRootPath, "image/petadopt", fileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    model.ImgFile.CopyTo(stream);
                }

                pet.ImageUrl = "image/petadopt/" + fileName;
            }

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        // DELETE
        public IActionResult Delete(int id)
        {
            var pet = _context.PetAdopts.Find(id);
            _context.PetAdopts.Remove(pet);

            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }





}

