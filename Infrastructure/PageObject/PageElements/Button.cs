using System;
using OpenQA.Selenium;
using Infrastructure.PageObject.PageElements.Interfaces;

namespace Infrastructure.PageObject.PageElements{
    public class Button : WebElement, IClickable
    {
        public Button(ISearchContext parent, By elementLocator) : base(parent, elementLocator)
        {
        }
    }
}