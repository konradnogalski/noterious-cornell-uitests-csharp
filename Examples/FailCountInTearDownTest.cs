using Infrastructure;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Examples
{
    [Explicit]
    public class FailCountInTearDownTest : TestFixtureBase
    {
        [Test]
        public void FailedTest()
        {
            Assert.Fail();
        }

        [Test]
        public void PassedTest()
        {
            Assert.That(TestContext.CurrentContext.Result.FailCount, Is.EqualTo(0), "Should keep context and have 0 failed asserts.");
        }

        protected override void TestTearDownAdditionalSteps()
        {
            var currentTestName = TestContext.CurrentContext.Test.MethodName;
            var expectedFailCount = currentTestName == nameof(FailedTest) ? 1 : 0;
            TestContext.WriteLine("TestMethod: " + currentTestName);

            Assert.That(TestContext.CurrentContext.Result.FailCount, Is.EqualTo(expectedFailCount), $"Should be {expectedFailCount} failed.");
        }
    }
}
