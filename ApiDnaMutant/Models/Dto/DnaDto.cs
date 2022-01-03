using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ApiDnaMutant.Models.Dto
{
    public class DnaDto
    {       
        public int Id { get; set; }
        public string DnaSequence { get; set; }
        public bool IsMutant { get; set; }
        public DateTime CreationDate { get; set; }

        [Required(ErrorMessage = "La secuencia del adn es obligatoria")]
        public string[] dna { get; set; }
    }
}
