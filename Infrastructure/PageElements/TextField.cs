using System;
using OpenQA.Selenium;

namespace Infrastructure.PageElements{
     public class TextField : PageElement, ISetable
    {
        public TextField(By locator, string displayName) : base(locator, displayName)
        {
        }

        public string Value => WebElement.Text;

        public void Set(string value)
        {
            WebElement.SendKeys(value);
        }
    }
}