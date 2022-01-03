using ApiDnaMutant.BusinessLogic.IBusinessLogic;
using ApiDnaMutant.Controllers;
using ApiDnaMutant.Models;
using ApiDnaMutant.Repository.IRepository;
using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Xunit;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {

        private readonly IDnaRepository _dnaRepo;
        private readonly IDnaLogic _dnaLogic;
        private readonly IMapper _mapper;


        [TestMethod]
        public void TestMethod1()
        {

            Mock<IDnaRepository> MockInaRepository = new Mock<IDnaRepository>();

            IDnaRepository transactionRepositoryMock = Substitute.For<IDnaRepository>();

            Mock<IDnaLogic> MockDnaLogic = new Mock<IDnaLogic>();
            Mock<IMapper> MockMapper = new Mock<IMapper>();


            DataTable table = new DataTable("Dna");
            DataColumn Id = new DataColumn("Id", typeof(int));
            DataColumn DnaSequense = new DataColumn("DnaSequense", typeof(string));
            DataColumn Ismutant = new DataColumn("Ismutant", typeof(int));
            DataColumn CreationDate = new DataColumn("CreationDate", typeof(DateTime));

            table.Columns.Add(Id);
            table.Columns.Add(DnaSequense);
            table.Columns.Add(Ismutant);
            table.Columns.Add(CreationDate);

            DataRow newRow = table.NewRow();
            newRow["Id"] = 1;
            newRow["DnaSequense"] = "ATGCGA,CAGTGC,TTATGT,AGAAGG,CCCCTA,TCACTG";
            newRow["Ismutant"] = 1;
            newRow["CreationDate"] = "2021-10-05 15:14:07.2094220";
            table.Rows.Add(newRow);

            //transactionRepositoryMock.GetDna.(table);


            //MockInaRepository.get

            //DnaController controller = new DnaController(MockInaRepository.Object, MockMapper.Object, MockDnaLogic.Object);

            //controller.GetDna().Returns(x => table);

            //controller.GetDna(table);



            //controller.GetDna(ds)


            //var s = controller.GetDna();




            //   var das =  controller.GetDna();

        }


        [Fact]
        public void GetOrders_WithOrdersInRepo_ReturnsOk()
        {

            IDnaRepository _DnaRepository = Substitute.For<IDnaRepository>();
            IDnaLogic _DnaLogic = Substitute.For<IDnaLogic>();
            IMapper _Mapper = Substitute.For<IMapper>();

            DnaController controller = new DnaController(_DnaRepository, _Mapper, _DnaLogic);





            Assert.Inconclusive();
            //// act
            //var result = controller.GetDna();
            //var okResult = result as Microsoft.AspNetCore.Mvc.OkObjectResult;

            //// assert
            //Assert.IsNotNull(okResult);
            //Assert.AreEqual(200, okResult.StatusCode);




        }

        [TestMethod]
        public void sdfsdfsdf()
        {

            IDnaRepository _DnaRepository = Substitute.For<IDnaRepository>();
            IDnaLogic _DnaLogic = Substitute.For<IDnaLogic>();
            IMapper _Mapper = Substitute.For<IMapper>();
            DnaController controller = new DnaController(_DnaRepository, _Mapper, _DnaLogic);

            //arrange



            DataTable table = new DataTable("Dna");
            DataColumn Id = new DataColumn("Id", typeof(int));
            DataColumn DnaSequense = new DataColumn("DnaSequense", typeof(string));
            DataColumn Ismutant = new DataColumn("Ismutant", typeof(int));
            DataColumn CreationDate = new DataColumn("CreationDate", typeof(DateTime));

            table.Columns.Add(Id);
            table.Columns.Add(DnaSequense);
            table.Columns.Add(Ismutant);
            table.Columns.Add(CreationDate);

            DataRow newRow = table.NewRow();
            newRow["Id"] = 1;
            newRow["DnaSequense"] = "ATGCGA,CAGTGC,TTATGT,AGAAGG,CCCCTA,TCACTG";
            newRow["Ismutant"] = 1;
            newRow["CreationDate"] = "2021-10-05 15:14:07.2094220";
            table.Rows.Add(newRow);

            DataSet ds = new DataSet();

            ds.Tables.Add(table);



            Dna objEmp = new Dna();

            List<Dna> empList = new List<Dna>();
            //foreach (DataRow dr in ds.Tables[0].Rows)
            //{
                empList.Add(new Dna { Id = 1, DnaSequence = "ATGCGA,CAGTGC,TTATGT,AGAAGG,CCCCTA,TCACTG", IsMutant = true, CreationDate = DateTime.Now });
            //}



            string ojo = "asd";



            _DnaRepository.GetDna().Returns(empList);


            var asd = _DnaRepository.GetDna();


        }


        [TestMethod]
        public void shoudReturnDnaResult()
        {
            //ARRANGE
            IDnaRepository _DnaRepository = Substitute.For<IDnaRepository>();
            IDnaLogic _DnaLogic = Substitute.For<IDnaLogic>();
            IMapper _Mapper = Substitute.For<IMapper>();
            DnaController controller = new DnaController(_DnaRepository, _Mapper, _DnaLogic);

            List<Dna> LResult = new List<Dna>();
            LResult.Add(new Dna { Id = 1, DnaSequence = "ATGCGA,CAGTGC,TTATGT,AGAAGG,CCCCTA,TCACTG", IsMutant = true, CreationDate = DateTime.Now });
            _DnaRepository.GetDna().Returns(LResult);

            //ACT
            var getDnaResult = controller.GetDna();

            //ASSERT}
            Assert.IsNotNull(getDnaResult);


        }


    }
}
