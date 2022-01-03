using Microsoft.VisualStudio.TestTools.UnitTesting;
using ApiDnaMutant.Controllers;
using Xunit;


namespace ApiDnaMutantTest
{
    [TestClass]
    public class uni
    {


        [Fact]
        public void GetOrders_WithOrdersInRepo_ReturnsOk()
        {

            DnaController controller = new DnaController();
          


            // act
            var result = controller.GetDna();
            var okResult = result as Microsoft.AspNetCore.Mvc.OkObjectResult;

            // assert
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);




        }
          
    }
    }




