using Infrastructure.PageElements;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using OpenQA.Selenium;

namespace Infrastructure{
    public class FluentAsserts
    {
        
        public FluentAsserts PageUrl(Constraint constraint){
            Assert.That(UITestContext.Driver.Url, constraint, "Incorrect page url");

            return this;
        }

        public FluentAsserts ErrorMessageWasDisplayed(){
            Assert.That(UITestContext.Driver.FindElement(By.CssSelector("form div.is-invalid")), Is.Not.Null, "No error message was displayed");

            return this;
        }

        public FluentAsserts Field(TextField textField, Constraint constraint){
            Assert.That(textField.Value, constraint, $"Incorrect value in field {textField.DisplayName}");

            return this;
        }
    }
}