using NUnit.Framework;
using System;
using System.IO;

namespace Infrastructure
{
     public class TestFixtureBase
     {

        private UITestContext _testContext;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {

            Configuration.Create();
            _testContext = new UITestContext(Configuration.ScreenshotsDirectory);
            
            CreateScreenshotsDirectory();
        }

        [SetUp]
        public void Setup()
        {
            _testContext.Initialize();
        }

        public FluentTestSteps.FluentTestSteps TestSteps => new FluentTestSteps.FluentTestSteps(_testContext);

        [TearDown]
        public void CleanUp()
        {
            try
            {
                TestTearDownAdditionalSteps();
                
                if (!_testContext.IsTestFailed())
                {
                    return;
                }

                _testContext.TakeScreenshot();

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

        private void CreateScreenshotsDirectory()
        {
            if (!Directory.Exists(Configuration.ScreenshotsDirectory))
            {
                Directory.CreateDirectory(Configuration.ScreenshotsDirectory);
            }
        }
    }
}