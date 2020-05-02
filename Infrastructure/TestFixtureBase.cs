using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;

namespace Infrastructure
{
     public class TestFixtureBase
     {
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
            UITestContext.Create(driver);
            _screenshotTaker = new ScreenshotTaker(driver, Configuration.ScreenshotsDirectory);
        }

        public FluentTestSteps.FluentTestSteps TestSteps => 
            new FluentTestSteps.FluentTestSteps(UITestContext.Driver);

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
                    $@"{NUnit.Framework.TestContext.CurrentContext.Test.MethodName}_{DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss")}.png");
            }
            catch (Exception e)
            {
                throw e;
            } 
            finally
            {
                UITestContext.Dispose();
            }
        }

        protected virtual void TestTearDownAdditionalSteps()
        {

        }

        private bool IsTestFailed()
        {
            return NUnit.Framework.TestContext.CurrentContext.Result.FailCount > 0;
        }
    }
}