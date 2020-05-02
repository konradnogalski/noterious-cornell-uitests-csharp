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
            Assert.That(NUnit.Framework.TestContext.CurrentContext.Result.FailCount, Is.EqualTo(0), "Should keep context and have 0 failed asserts.");
        }

        protected override void TestTearDownAdditionalSteps()
        {
            var currentTestName = NUnit.Framework.TestContext.CurrentContext.Test.MethodName;
            var expectedFailCount = currentTestName == nameof(FailedTest) ? 1 : 0;
            NUnit.Framework.TestContext.WriteLine("TestMethod: " + currentTestName);

            Assert.That(NUnit.Framework.TestContext.CurrentContext.Result.FailCount, Is.EqualTo(expectedFailCount), $"Should be {expectedFailCount} failed.");
        }
    }
}
