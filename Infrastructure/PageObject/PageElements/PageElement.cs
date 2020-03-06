using System;
using OpenQA.Selenium;

namespace Infrastructure.PageObject.PageElements{
    public abstract class PageElement
    {
        private Func<IWebElement> _webElementFinder;
        protected IWebElement WebElement => _webElementFinder.Invoke();
        public string DisplayName {get; private set;}
        protected PageElement(Func<IWebElement> webElementFinder, string displayName)
        {
            _webElementFinder = webElementFinder;
            DisplayName = displayName;
        }
    }
}