using NUnit.Framework;
using NUnit.Framework.Constraints;
using Infrastructure.PageObject.PageElements;
using Infrastructure.PageObject;

namespace Infrastructure.FluentTestSteps
{
    public class PageFluentAsserts
    {
        private IPageObject _pageObject;
        public PageFluentAsserts(IPageObject pageobject)
        {
            _pageObject = pageobject;
        }
        public PageFluentAsserts PageUrl(Constraint constraint){
            Assert.That(_pageObject.RelativeUrl, constraint, "Incorrect page url");

            return this;
        }

        public PageFluentAsserts ErrorMessageWasDisplayed(){
            Assert.That(((IHasErrorsPage)_pageObject)?.HasErrors(), Is.True, "No error message was displayed");

            return this;
        }

        public PageFluentAsserts Field(IHasInputField textField, Constraint constraint){
            Assert.That(textField.Value, constraint, $"Incorrect value in '{textField.Label}' field.");

            return this;
        }
    }
}