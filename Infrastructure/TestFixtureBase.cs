using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;

namespace Infrastructure
{
     public class TestFixtureBase
     {
        private UITestContext _testContext;
        private ScreenshotTaker _screenshotTaker;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            Configuration.Create();
        }

        [SetUp]
        public void Setup()
        {
            var driver = new ChromeDriver();
            _testContext = new UITestContext(driver);
            _screenshotTaker = new ScreenshotTaker(driver, Configuration.ScreenshotsDirectory);
        }

        public FluentTestSteps.FluentTestSteps TestSteps => 
            new FluentTestSteps.FluentTestSteps(_testContext.Driver);

        [TearDown]
        public void CleanUp()
        {
            try
            {
                TestTearDownAdditionalSteps();
                
                if (!IsTestFailed())
                {
                    return;
                }

                _screenshotTaker.TakeScreenshot(
                    $@"{TestContext.CurrentContext.Test.MethodName}_{DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss")}.png");
            }
            catch (Exception e)
            {
                throw e;
            } 
            finally
            {
                _testContext.Dispose();
            }
        }

        protected virtual void TestTearDownAdditionalSteps()
        {

        }

        private bool IsTestFailed()
        {
            return TestContext.CurrentContext.Result.FailCount > 0;
        }
    }
}