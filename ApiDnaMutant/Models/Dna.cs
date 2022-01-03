using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiDnaMutant.Models
{
    public class Dna
    {
        [Key]
        public int Id { get; set; }
        public string DnaSequence { get; set; }
        public bool IsMutant { get; set; }
        public DateTime CreationDate { get; set; }
        
        [NotMapped]
        public string[] dna { get; set; }
    }
}
