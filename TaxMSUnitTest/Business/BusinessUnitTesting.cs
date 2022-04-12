using AutoFixture;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaxCommon;

namespace TaxMSUnitTest.Business
{
    [TestClass]
    public class BusinessUnitTesting: BusinessSetup
    {
        [TestMethod]
        public void Business_GetTaxDetailsWithValidEntityRole1()
        {
            //arrage
            string name = fixture.Create<string>();
            var resposModel = fixture.Create<RequestModel>();
            var reposResponse =new List<TaxRuleRate>();
            reposResponse.Add(new TaxRuleRate() { RuleId = 1, Rate = decimal.Parse("0.10"), TaxTime = "Yearly" });
            mockRepository.Setup(x => x.GetRule(It.IsAny<string>())).Returns(1);
            mockRepository.Setup(x => x.GetTaxes(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>())).Returns(reposResponse);

            //act
            var businessResponse = business.GetTaxDetails(resposModel);

            //Assert
            Assert.IsNotNull(businessResponse);
        }
        [TestMethod]
        public void Business_GetTaxDetailsWithValidEntityRole2()
        {
            //arrage
            string name = fixture.Create<string>();
            var resposModel = fixture.Create<RequestModel>();
            var reposResponse = new List<TaxRuleRate>();
            reposResponse.Add(new TaxRuleRate() { RuleId = 1, Rate = decimal.Parse("0.10"), TaxTime = "Yearly" });
            mockRepository.Setup(x => x.GetRule(It.IsAny<string>())).Returns(2);
            mockRepository.Setup(x => x.GetTaxes(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>())).Returns(reposResponse);

            //act
            var businessResponse = business.GetTaxDetails(resposModel);

            //Assert
            Assert.IsNotNull(businessResponse);
        }
        [TestMethod]
        public void Business_GetTaxDetailsWithNull()
        {
            //arrage
            string name = fixture.Create<string>();
            var resposModel = fixture.Create<RequestModel>();
            var reposResponse = new List<TaxRuleRate>();
            reposResponse = null;
            mockRepository.Setup(x => x.GetRule(It.IsAny<string>())).Returns(0);
            mockRepository.Setup(x => x.GetTaxes(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>())).Returns(reposResponse);

            //act
            var businessResponse = business.GetTaxDetails(resposModel);

            //Assert
            Assert.IsNotNull(businessResponse);
        }
    }
}
