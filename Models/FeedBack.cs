using System.ComponentModel.DataAnnotations;

namespace MyPets.Models
{
    public class FeedBack
    {
        [Key]
        public int FId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, ErrorMessage = "Name cannot exceed 50 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Message is required")]
        [StringLength(500, ErrorMessage = "Message cannot exceed 500 characters")]
        public string Message { get; set; }

        [Required(ErrorMessage = "Passion is required")]
        [StringLength(50, ErrorMessage = "Passion cannot exceed 50 characters")]
        public string Passion { get; set; }


        public string? ImagePath { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public bool IsApproved { get; set; } = false;

    }
}
