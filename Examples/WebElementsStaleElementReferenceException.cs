using Infrastructure;
using Infrastructure.PageObject.PageElements;
using NUnit.Framework;
using OpenQA.Selenium;
using PageObjects;

namespace Examples
{
    public class WebElementsStaleElementReferenceException : BaseUITestTemplate
    {
        [Test]
        public void GiventParentAndChildStaleElement_WhenFirstCallToThatElementIsMade_ShouldNotThrowStaleElementReferenceException()
        {
            WebElement soonToBeStaleParentElement = null;
            WebElement soonToBeStaleChildElement = null;
            TestSteps()
                .GoTo<ExamplesPage>((page, a) =>
                {
                    soonToBeStaleParentElement = page.Form;
                    soonToBeStaleChildElement = page.FirstInputElement;
                })
                .GoTo<ExamplesPage>((page, a) =>
                {
                    Assert.Multiple(() =>
                    {
                        Assert.That(soonToBeStaleParentElement.IsStale, Is.False, "Parent is not stale, as it was not cached yet (lazy loading).");
                        Assert.That(soonToBeStaleChildElement.IsStale, Is.False, "Child element is not stale, as it was not loaded yet (lazy loading).");
                        
                        Assert.That(() => MakeACallTo(soonToBeStaleChildElement),
                            Throws.Nothing,
                            $"Should not throw {typeof(StaleElementReferenceException)} neither on parent element, nor on child element.");
                        Assert.That(soonToBeStaleParentElement.IsStale, Is.False, "Parent should not be staled. Nothing has changed.");
                        Assert.That(soonToBeStaleChildElement.IsStale, Is.False, "Child element should not be staled. Nothing has changed.");
                    });
                });
        }

        [Test]
        public void GivenCachedAndStaledParentAndChildElements_WhenSubsequentCallsToChildElementAreMade_ShouldNotThrowStaleElementReferenceException()
        {
            WebElement soonToBeStaleParentElement = null;
            WebElement soonToBeStaleChildElement = null;
            TestSteps()
                .GoTo<ExamplesPage>((page, a) =>
                {
                    soonToBeStaleParentElement = page.Form;
                    soonToBeStaleChildElement = page.FirstInputElement;

                    Assert.Multiple(() =>
                    {
                        MakeACallTo(soonToBeStaleChildElement);
                        Assert.That(soonToBeStaleParentElement.IsCached, Is.True, "Parent should be cached.");
                        Assert.That(soonToBeStaleChildElement.IsCached, Is.True, "Child element should be cached.");
                    });
                })
                .GoTo<ExamplesPage>((page, a) =>
                {
                    Assert.Multiple(() =>
                    {
                        Assert.That(soonToBeStaleParentElement.IsStale, Is.True, "Parent should be staled now.");
                        Assert.That(soonToBeStaleChildElement.IsStale, Is.True, "Child element should be staled now.");

                        //Test starts here
                        Assert.That(() => MakeACallTo(soonToBeStaleChildElement),
                            Throws.Nothing,
                            $"Should not throw {typeof(StaleElementReferenceException)} neither on parent element, nor on child element.");
                        Assert.That(soonToBeStaleParentElement.IsStale, Is.False, "Parent should not be staled anymore as it was recached.");
                        Assert.That(soonToBeStaleChildElement.IsStale, Is.False, "Child element should not be staled anymore as it was recached.");
                        Assert.That(() => MakeACallTo(soonToBeStaleChildElement),
                            Throws.Nothing,
                            $"Should not throw {typeof(StaleElementReferenceException)} neither on parent element, nor on child element.");
                    });
                });
        }

        private void MakeACallTo(WebElement webElement)
        {
            var _ = webElement.Displayed;
        }
    }
}