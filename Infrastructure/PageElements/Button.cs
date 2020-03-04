using System;
using OpenQA.Selenium;

namespace Infrastructure.PageElements{
    public class Button : PageElement, IClickable
    {
        public Button(By locator, string displayName) : base(locator, displayName)
        {
        }
        public void Click()
        {
            WebElement.Click();
        }
    }
}