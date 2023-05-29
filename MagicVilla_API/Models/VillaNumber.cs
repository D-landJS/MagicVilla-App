using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MagicVilla_API.Models
{
    public class VillaNumber
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int VillaNo { get; set; }

        [Required]
        public int VillaId { get; set; }

        [ForeignKey("VillaId")]
        public Villa Villa { get; set; }

        public string SpecialDetail { get; set; }

        public DateTime DateCreate { get; set; }

        public DateTime UpdateDate { get; set; }
    }
}
