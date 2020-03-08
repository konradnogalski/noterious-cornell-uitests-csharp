using System;
using OpenQA.Selenium;
using Infrastructure.PageObject.PageElements.Interfaces;

namespace Infrastructure.PageObject.PageElements{
    public class Button : PageElement, IClickable
    {
        public Button(IWebElement webElement) : base(webElement)
        {
        }
        public void Click()
        {
            WebElement.Click();
        }
    }
}