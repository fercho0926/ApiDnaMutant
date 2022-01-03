using ApiDnaMutant.BusinessLogic.IBusinessLogic;
using ApiDnaMutant.Controllers;
using ApiDnaMutant.Repository.IRepository;
using AutoMapper;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using ApiDnaMutant.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace TestProject1
{
    [TestClass]
    public class sustituteTest
    {
        IDnaRepository _DnaRepository = Substitute.For<IDnaRepository>();
        IDnaLogic _DnaLogic = Substitute.For<IDnaLogic>();
        IMapper _Mapper = Substitute.For<IMapper>();

        
        public sustituteTest() {
            DnaController controller = new DnaController(_DnaRepository, _Mapper, _DnaLogic);
        }

        [Fact]
        public async Task getasdDNA() {

            //arrange

        
            var dnaMoq = new Dna { Id = 1, DnaSequence = "ATGCGA,CAGTGC,TTATGT,AGAAGG,CCCCTA,TCACTG", IsMutant = true, CreationDate = DateTime.Now };

            _DnaRepository.GetDna().Returns((ICollection<Dna>)dnaMoq);


            var asd  = _DnaRepository.GetDna();



            //act


            //Assert



        } 


    }
}
