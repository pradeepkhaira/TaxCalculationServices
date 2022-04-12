using APITaxCalculation.Controllers;
using Microsoft.Extensions.Logging;
using Moq;
using TaxBusiness;
using TaxMSUnitTest.BaseSetup;

namespace TaxMSUnitTest.Controller
{
    public abstract class ControllerSetup : UnitTestingBaseSetup
    {
        protected readonly Mock<ITaxBusiness> business;
        protected readonly TaxController controller;
        private readonly Mock<ILogger<TaxController>> logger;
        protected ControllerSetup()
        {
            business = new Mock<ITaxBusiness>();
            logger = new Mock<ILogger<TaxController>>();
            controller = new TaxController(business.Object, logger.Object);
        }
    }
}
