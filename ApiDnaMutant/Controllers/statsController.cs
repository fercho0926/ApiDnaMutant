using ApiDnaMutant.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiDnaMutant.Controllers
{
    [Route("api/stats")]
    [ApiController]
    public class statsController : ControllerBase
    {
        private readonly IDnaRepository _dnaRepo;

        public statsController(IDnaRepository dnaRepo)
        {
            _dnaRepo = dnaRepo;
        }

        [HttpGet]
        public IActionResult stats()
        {
            var stats = _dnaRepo.Getstats();
            return Ok(stats);
        }
    }
}
