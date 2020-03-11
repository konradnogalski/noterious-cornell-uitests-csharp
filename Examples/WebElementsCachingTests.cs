using Infrastructure;
using Infrastructure.PageObject.PageElements;
using NUnit.Framework;
using PageObjects;

namespace Examples
{
    public class WebElementsCachingTests : TestFixtureBase
    {
        [Test]
        public void GivenNotCachedElement_WhenFirstCallToElementIsMade_ShouldCacheElement()
        {
            TestSteps
                .GoTo<ExamplesPage>((page, a) =>
                {
                    Assert.Multiple(() =>
                    {
                        var parentElement = page.Form;

                        Assert.That(parentElement.IsCached, Is.False, "Should not be cached");
                        
                        TriggerCachingMechanismOn(parentElement);
                        Assert.That(page.Form.IsCached, Is.True, "Should be cached");
                    });
                });
        }

        [Test]
        public void GivenNotCachedParentAndChildElement_WhenFirstCallToChildElementIsMade_ShouldCacheBothElements()
        {
            TestSteps
                .GoTo<ExamplesPage>((page, a) =>
                {
                    Assert.Multiple(() =>
                    {
                        var parentElement = page.Form;
                        var childElement = page.FirstInputElement;

                        Assert.That(parentElement.IsCached, Is.False, "Parent should not be cached");
                        Assert.That(childElement.IsCached, Is.False, "Child element should not be cached");

                        TriggerCachingMechanismOn(childElement);
                        Assert.That(page.Form.IsCached, Is.True, "Parent should be cached.");
                        Assert.That(page.FirstInputElement.IsCached, Is.True, "Parent should be cached.");
                    });
                });
        }

        private void TriggerCachingMechanismOn(WebElement webElement)
        {
            var _ = webElement.Displayed;
        }
    }
}