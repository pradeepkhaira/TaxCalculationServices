using AutoFixture;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using TaxCommon;

namespace TaxMSUnitTest.Controller
{
    [TestClass]
    public class APIUnitTesting : ControllerSetup
    {
        [TestMethod]
        public void Business_GetTaxDetailsWithValidEntity()
        {
            //arrage
            string name = fixture.Create<string>();
            var resposModel = fixture.Create<RequestModel>();
            var reposResponse = fixture.Create<ResponseModel>();
            business.Setup(x => x.GetTaxDetails(resposModel)).Returns(reposResponse);

            //act
            var businessResponse = controller.Post(resposModel);

            //Assert
            Assert.IsNotNull(businessResponse);
        }
        [TestMethod]
        public void Business_GetTaxDetailsWithNullData()
        {
            //arrage
            string name = fixture.Create<string>();
            var resposModel = fixture.Create<RequestModel>();
            var reposResponse = fixture.Create<ResponseModel>();
            reposResponse = null;
            business.Setup(x => x.GetTaxDetails(resposModel)).Returns(reposResponse);

            //act
            var businessResponse = controller.Post(resposModel);

            //Assert
            Assert.IsNotNull(businessResponse);
        }
    }
}
