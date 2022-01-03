using ApiDnaMutant.Data;
using ApiDnaMutant.Models;
using ApiDnaMutant.Models.Dto;
using ApiDnaMutant.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace ApiDnaMutant.Repository
{
    public class DnaRepository : IDnaRepository
    {
        private readonly ApplicationDbContext _db;

        public DnaRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public bool CreateDna(Dna dna)
        {
            _db.Dna.Add(dna);
            return Save();
        }

        public bool DnaExists(string dnaSequence)
        {
            bool value = _db.Dna.Any(d => d.DnaSequence.ToLower().Trim() == dnaSequence.ToLower().Trim());
            return value;
        }

        public bool DnaExists(int id)
        {
            return _db.Dna.Any(d => d.Id == id);
        }

        public ICollection<Dna> GetDna()
        {
            return _db.Dna.OrderBy(d => d.DnaSequence).ToList();
        }

        public Dna GetDna(int id)
        {
            return _db.Dna.FirstOrDefault(d => d.Id == id);
        }
        public bool DropDna(Dna dna)
        {
            _db.Dna.Remove(dna);
            return Save();
        }
        public StatsDto Getstats()
        {
            StatsDto statsDto = new StatsDto();

            statsDto.count_mutant_dna = _db.Dna.Count(d => d.IsMutant == true);
            statsDto.count_human_dna = _db.Dna.Count(d => d.IsMutant == false);

            if (statsDto.count_mutant_dna > 0 && statsDto.count_human_dna > 0)
            {
                statsDto.ratio = Convert.ToDouble((statsDto.count_mutant_dna / statsDto.count_human_dna));                
            }

            return statsDto;
        }
        public bool Save()
        {
            return _db.SaveChanges() >= 0 ? true : false;
        }
    }
}
