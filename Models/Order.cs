using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyPets.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }


        [Required]
        public int ProductId { get; set; }


        [ForeignKey("ProductId")]
        public Product? Product { get; set; }




        [Required(ErrorMessage = "Customer name is required")]
        [StringLength(50, ErrorMessage = "Name cannot exceed 50 characters")]
        public string CustomerName { get; set; }

        [Required(ErrorMessage = "Address is required")]
        [StringLength(200, ErrorMessage = "Address cannot exceed 200 characters")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        [Phone(ErrorMessage = "Invalid phone number")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Quantity is required")]
        [Range(1, 100, ErrorMessage = "Quantity must be at least 1")]
        public int Quantity { get; set; }
        [Required]
        public string Status { get; set; } = "Pending";

        [Required]
        public DateTime OrderDate { get; set; } = DateTime.Now;

    }
}
