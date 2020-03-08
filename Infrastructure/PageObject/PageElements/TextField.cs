using System;
using OpenQA.Selenium;

namespace Infrastructure.PageObject.PageElements{
    public class TextField : PageElement, IHasInputField
    {
        public TextField(IWebElement webElement) : base(webElement)
        {
        }
        public string Label => ((WebElement)WebElement)?.Parent?.FindElement(By.CssSelector($"label[for='{Id}']"))?.Text;

        public string Value => WebElement?.GetAttribute("value");

        public void Set(string value)
        {
            WebElement.SendKeys(value);
        }
    }
}