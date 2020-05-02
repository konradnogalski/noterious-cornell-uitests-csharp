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
            var firstRow = _rows.FirstOrDefault();
            return firstRow != null ? new Row(firstRow) : null;
        }

        public Row GetLastRow()
        {
            var lastRow = _rows.LastOrDefault();
            return lastRow != null ? new Row(lastRow) : null;
        }
    }
}
