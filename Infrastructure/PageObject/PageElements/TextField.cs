using System;
using OpenQA.Selenium;
using Infrastructure.PageObject.PageElements.Interfaces;

namespace Infrastructure.PageObject.PageElements{
    public class TextField : PageElement, ISetable
    {
        public TextField(Func<IWebElement> webElement, string displayName) : base(webElement, displayName)
        {
        }

        public string Value => WebElement?.GetAttribute("value");

        public void Set(string value)
        {
            WebElement.SendKeys(value);
        }
    }
}