using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.PageObject.PageElements
{
    public class Table : WebElement
    {
        public Table(ISearchContext parent, By elementLocator) : base(parent, elementLocator)
        {

        }

        private IEnumerable<IWebElement> _rows => FindElements(By.CssSelector("tbody > tr"));

        public Row GetFirstRow()
        {
            return new Row(_rows.First());
        }
    }
}
