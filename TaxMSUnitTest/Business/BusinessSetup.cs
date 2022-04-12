using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxBusiness;
using TaxDataAccess;
using TaxMSUnitTest.BaseSetup;

namespace TaxMSUnitTest.Business
{
    public abstract class BusinessSetup : UnitTestingBaseSetup
    {
        protected readonly Mock<ITaxData> mockRepository;
        protected readonly TaxBusinessClass business;
        private readonly Mock<ILogger<TaxBusinessClass>> logger;
        protected BusinessSetup()
        {
            mockRepository = new Mock<ITaxData>();
            logger = new Mock<ILogger<TaxBusinessClass>>();
            business = new TaxBusinessClass(mockRepository.Object, logger.Object);
        }
    }
}
