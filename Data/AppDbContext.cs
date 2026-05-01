using Microsoft.EntityFrameworkCore;
using MyPets.Models;
namespace MyPets.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<AdminLogin> AdminLogins { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<PetAdopt> PetAdopts { get; set; }


        public DbSet<Order> Orders { get; set; }

        public DbSet<ServiceBooking> ServiceBookings { get; set; }

        public DbSet<FeedBack> FeedBacks { get; set; }



    }
}
