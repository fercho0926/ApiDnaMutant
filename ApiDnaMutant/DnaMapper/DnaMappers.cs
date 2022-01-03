using ApiDnaMutant.Models;
using ApiDnaMutant.Models.Dto;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiDnaMutant.DnaMapper
{
    public class DnaMappers : Profile
    {
        public DnaMappers()
        {
            CreateMap<Dna, DnaDto>().ReverseMap();
        }

    }
}
