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


        public PageFluentAsserts HasErrors()
        {
            var pageErrors = ((IHasErrorsPage)_pageObject)?.Errors;
            Assert.That(pageErrors.Count, Is.GreaterThan(0), "No errors are displayed");

            return this;
        }

        public PageFluentAsserts HasNoErrors()
        {
            var pageErrors = ((IHasErrorsPage)_pageObject)?.Errors;
            Assert.That(pageErrors.Count, Is.EqualTo(0), "Errors are displayed");

            return this;
        }

        public PageFluentAsserts ErrorsContains(string errorMessage){
            Assert.That(((IHasErrorsPage)_pageObject)?.Errors, Contains.Item(errorMessage), $"'{errorMessage}' was not displayed");

            return this;
        }

        public PageFluentAsserts Field(IHasInputField textField, Constraint constraint){
            Assert.That(textField.Value, constraint, $"Incorrect value in '{textField.DisplayedText}' field.");

            return this;
        }

        public PageFluentAsserts LabelDisplayedText(string label, Constraint constraint)
        {
            Assert.That(label, constraint, $"Incorrect logged user.");

            return this;
        }
    }
}