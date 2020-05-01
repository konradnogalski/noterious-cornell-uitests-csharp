using System;
using OpenQA.Selenium;

namespace Infrastructure.PageObject.PageElements{
    public class TextField : WebElement, IHasInputField
    {
        public TextField(ISearchContext parent, By cssSelector) : base(parent, cssSelector)
        {
        }
        public string DisplayedText => Parent?.FindElement(By.CssSelector($"label[for='{GetAttribute("Id")}']"))?.Text;

        public string Value => GetAttribute("value");

        public void Set(string value)
        {
            SendKeys(value);
        }
    }
}