using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using Infrastructure.FluentTestSteps;

namespace Infrastructure
{
     public class BaseUITestTemplate
     {
        private UITestContext _testContext;

        [SetUp]
        public void Setup()
        {
            _testContext = new UITestContext(new ChromeDriver());
        }

        public TestSteps TestSteps(){
            return new TestSteps(_testContext);
        }

        [TearDown]
        public void CleanUp()
        {
            _testContext.CleanUp();
        }
     }
}