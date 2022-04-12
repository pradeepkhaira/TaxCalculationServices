using AutoFixture;
using AutoFixture.AutoMoq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxUnitTest.BaseSetup
{
    public abstract class UnitTestingBaseSetup
    {
        protected readonly IFixture fixture;
        protected UnitTestingBaseSetup()
        {
            fixture = new Fixture();
            fixture.Customize(new AutoMoqCustomization() { ConfigureMembers = true })
                   .Behaviors.Add(new OmitOnRecursionBehavior());
        }
    }
}
