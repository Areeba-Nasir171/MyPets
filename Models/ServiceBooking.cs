using System.ComponentModel.DataAnnotations;

namespace MyPets.Models
{
    public class ServiceBooking
    {
        [Key]
        public int SId { get; set; }

        [Required(ErrorMessage = "Pet name is required")]
        [StringLength(50, ErrorMessage = "Pet name cannot exceed 50 characters")]
        public string PetName { get; set; }

        [Required(ErrorMessage = "Owner name is required")]
        [StringLength(50, ErrorMessage = "Owner name cannot exceed 50 characters")]
        public string OwnerName { get; set; }

        [Required(ErrorMessage = "Please select a service")]
        public string ServiceType { get; set; }

        [Required(ErrorMessage = "Date is required")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Time is required")]
        [DataType(DataType.Time)]
        public string Time { get; set; }

        [Required]
        public string Status { get; set; } = "Pending";

    }
}
