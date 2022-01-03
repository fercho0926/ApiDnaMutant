using ApiDnaMutant.BusinessLogic.IBusinessLogic;
using ApiDnaMutant.Models;
using ApiDnaMutant.Models.Dto;
using ApiDnaMutant.Repository.IRepository;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiDnaMutant.Controllers
{
    [Route("api/mutant")]
    [ApiController]
    public class DnaController : ControllerBase
    {
        private readonly IDnaRepository _dnaRepo;
        private readonly IDnaLogic _dnaLogic;
        private readonly IMapper _mapper;
        public DnaController(IDnaRepository dnaRepo, IMapper mapper, IDnaLogic dnaLogic)
        {
            _dnaRepo = dnaRepo;
            _mapper = mapper;
            _dnaLogic = dnaLogic;
        }

        [HttpGet]
        public IActionResult GetDna()
        {
            var listDna = _dnaRepo.GetDna();

            var ListDnaDto = new List<DnaDto>();

            foreach(var list in listDna)
            {
                ListDnaDto.Add(_mapper.Map<DnaDto>(list));
            }

            return Ok(ListDnaDto);
        }

        [HttpGet("{id:int}", Name = "GetDna")]
        public IActionResult GetDna(int id)
        {
            var itemDna = _dnaRepo.GetDna(id);

            if (itemDna == null)
            {
                return NotFound();
            }

            var itemDnaDto = _mapper.Map<DnaDto>(itemDna);

            return Ok(itemDnaDto);
        }

        [HttpPost]
        public IActionResult CrearDna([FromBody] DnaDto dnaDto)
        {   
            if (dnaDto == null || dnaDto.dna == null)
            {
                return BadRequest(ModelState);
            }
            else
            {
                bool isMutant = false;
                bool validFormat = _dnaLogic.ValidateDna(dnaDto);

                if (validFormat)
                {
                    dnaDto.DnaSequence = String.Join(",", dnaDto.dna).ToString();
                    isMutant = _dnaLogic.IsMutant(dnaDto);

                    if (_dnaRepo.DnaExists(dnaDto.DnaSequence))
                    {
                        ModelState.AddModelError("", "the dna already exist");
                        return StatusCode(404, ModelState);
                    }

                    var dnaModel = _mapper.Map<Dna>(dnaDto);
                    dnaModel.IsMutant = isMutant;
                    dnaModel.CreationDate = DateTime.Now;

                    if (!_dnaRepo.CreateDna(dnaModel))
                    {
                        ModelState.AddModelError("", $"Algo salio mal guardando el registro del adn{dnaModel.DnaSequence}");
                        return StatusCode(500, ModelState);
                    }

                    if (!isMutant)
                    {
                        return StatusCode(StatusCodes.Status403Forbidden);
                    }
                    else
                    {
                        return Ok();
                    }

                }
                else
                {
                    ModelState.AddModelError("", "la secuencia no es correcta");
                    return StatusCode(404, ModelState);
                }
            }
        }

        [HttpDelete("{id:int}", Name = "DropDna")]
        public IActionResult DropDna(int id)
        {
            if (!_dnaRepo.DnaExists(id))
            {
                return NotFound();
            }            

            var dna = _dnaRepo.GetDna(id);

            if (!_dnaRepo.DropDna(dna))
            {
                ModelState.AddModelError("", $"Algo salio mal borrando el registro {dna.DnaSequence}");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }
    }
}
