using AutoFixture;
using AutoFixture.AutoMoq;

namespace TaxMSUnitTest.BaseSetup
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
