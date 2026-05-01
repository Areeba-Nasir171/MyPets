using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyPets.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Product Name is Required")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Name must be between 3 to 100 Characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Category is Required")]
        public string Category { get; set; }

        [Required(ErrorMessage = "Price is Required")]
        [Range(1, 100000, ErrorMessage = ("Price must be greater then 0"))]
        public decimal Price { get; set; }

        [Required(ErrorMessage = ("Description is Required"))]
        [StringLength(500, ErrorMessage = ("Description cannot exceed 500 charachters"))]
        public string? Description { get; set; }

        
        public string? ImageUrl { get; set; }

       
        [NotMapped]
        [Required(ErrorMessage = "Please choose an image file")]
        public IFormFile ImageFile { get; set; }
    }
}
