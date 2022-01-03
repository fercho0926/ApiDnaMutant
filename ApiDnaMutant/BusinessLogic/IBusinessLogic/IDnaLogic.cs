using ApiDnaMutant.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiDnaMutant.BusinessLogic.IBusinessLogic
{
    public interface IDnaLogic
    {
        bool ValidateDna(DnaDto dnaDto);
        bool IsMutant(DnaDto dnaDto);
    }
}
