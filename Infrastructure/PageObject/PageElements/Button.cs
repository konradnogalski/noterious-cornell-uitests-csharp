using System;
using OpenQA.Selenium;
using Infrastructure.PageObject.PageElements.Interfaces;

namespace Infrastructure.PageObject.PageElements{
    public class Button : PageElement, IClickable
    {
        public Button(Func<IWebElement> webElementFinder, string displayName) : base(webElementFinder, displayName)
        {
        }
        public void Click()
        {
            WebElement.Click();
        }
    }
}