using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyPets.Models
{
    public enum PetStatus
    {
        Adopted,
        NotAdopted
    }
    public class PetAdopt
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Pet Name is Required")]
        [StringLength(15, MinimumLength = 3, ErrorMessage = "Pet Name must be between 3 to 15 Characters")]
        public string PetName { get; set; }

        public string? ImageUrl { get; set; }

        [NotMapped]
        [Required(ErrorMessage = "Please choose an image file")]
        public IFormFile ImgFile { get; set; }

        public PetStatus Status { get; set; }
    }
}
