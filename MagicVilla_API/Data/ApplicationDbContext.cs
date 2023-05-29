using MagicVilla_API.Models;
using Microsoft.EntityFrameworkCore;

namespace MagicVilla_API.Data
{
    // Heredamos de DBContext para crear la tabla 
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // Se le asigna que entidad sera una tabla
        public DbSet<Villa> Villas { get; set; }
        public DbSet<VillaNumber> VillaNumbers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Villa>().HasData(
                 new Villa()
                 {
                     Id = 1,
                     Name = "Villa Real",
                     Details = "",
                     Occupants = 5,
                     ImageUrl = "",
                     MetersSquared = 50,
                     Fee = 200,
                     Amenity = "",
                     DateCreate = DateTime.Now,
                     UpdateDate = DateTime.Now,


                 },
                new Villa()
                {
                    Id = 2,
                    Name = "Premium Vista a la Piscina",
                    Details = "",
                    Occupants = 4,
                    ImageUrl = "",
                    MetersSquared = 50,
                    Fee = 150,
                    Amenity = "",
                    DateCreate = DateTime.Now,
                    UpdateDate = DateTime.Now,


                });
        }

    }
}
