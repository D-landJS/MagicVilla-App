using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MagicVilla_API.Models
{
    public class Villa
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public required string Name { get; set; }

        [Required]
        public double Fee { get; set; }

        public string Details { get; set; }

        public int Occupants { get; set; }

        public int MetersSquared { get; set; }

        public string ImageUrl { get; set; }

        public string Amenity { get; set; }

        public DateTime DateCreate { get; set; }

        public DateTime UpdateDate { get; set; }

    }
}
