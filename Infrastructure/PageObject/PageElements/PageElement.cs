using System;
using OpenQA.Selenium;

namespace Infrastructure.PageObject.PageElements{
    public abstract class PageElement
    {
        protected readonly IWebElement WebElement;
        public PageElement(IWebElement webElement)
        {
            WebElement = webElement;
        }

        public string Id => WebElement.GetAttribute("id");
    }
}