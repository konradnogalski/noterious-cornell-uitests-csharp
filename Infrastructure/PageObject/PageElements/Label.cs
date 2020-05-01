using System;
using OpenQA.Selenium;

namespace Infrastructure.PageObject.PageElements
{
    public class Label : WebElement, IHasLabel
    {
        public Label(ISearchContext parent, By elementLocator) : base(parent, elementLocator)
        {
        }
        public string DisplayedText => Text;
    }
}
