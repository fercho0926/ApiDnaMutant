using ApiDnaMutant.Models;
using ApiDnaMutant.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiDnaMutant.Repository.IRepository
{
    public interface IDnaRepository
    {
        ICollection<Dna> GetDna();
        Dna GetDna(int id);
        bool DnaExists(string dnaSequence);
        bool DnaExists(int id);
        bool CreateDna(Dna dna);
        bool DropDna(Dna dna);
        StatsDto Getstats();
        bool Save();
    }
}
