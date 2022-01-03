using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiDnaMutant.Models.Dto
{
    public class StatsDto
    {
        public double count_mutant_dna { get; set; }
        public double count_human_dna { get; set; }
        public double ratio { get; set; }
    }
}
