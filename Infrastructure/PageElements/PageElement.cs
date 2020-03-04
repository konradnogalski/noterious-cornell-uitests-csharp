using System;
using OpenQA.Selenium;

namespace Infrastructure.PageElements{
    public abstract class PageElement
    {
        private By _locator;
        public string DisplayName {get; private set;}
        protected PageElement(By locator, string displayName)
        {
            _locator = locator;
        }
        protected IWebElement WebElement => UITestContext.Driver.FindElement(_locator);
    }
}