using System.ComponentModel.DataAnnotations;

namespace MagicVilla_API.Models.Dto
{
    public class VillaUpdateDto
    {

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        public string Details { get; set; }

        [Required]
        public double Fee { get; set; }

        [Required]
        public int Occupants { get; set; }

        [Required]
        public int MetersSquared { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        public string Amenity { get; set; }
    }
}
