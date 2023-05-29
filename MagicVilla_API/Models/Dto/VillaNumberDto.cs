﻿using System.ComponentModel.DataAnnotations;

namespace MagicVilla_API.Models.Dto
{
    public class VillaNumberDto
    {
        public int VillaNo { get; set; }

        [Required]
        public int VillaId { get; set; }

        public string SpecialDetail { get; set; }
    }
}
