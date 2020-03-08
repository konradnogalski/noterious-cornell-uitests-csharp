using NUnit.Framework;
using NUnit.Framework.Constraints;
using Infrastructure.PageObject.PageElements;

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
            Assert.That(_pageObject.Url, constraint, "Incorrect page url");

            return this;
        }

        public PageFluentAsserts ErrorMessageWasDisplayed(){
            Assert.That(_pageObject.HasErrors(), Is.True, "No error message was displayed");

            return this;
        }

        public PageFluentAsserts Field(TextField textField, Constraint constraint){
            Assert.That(textField.Value, constraint, $"Incorrect value in '{textField.DisplayName}' field.");

            return this;
        }
    }
}