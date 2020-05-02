using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.PageObject.PageElements
{
    public class Row
    {
        private IWebElement _row;
        public Row(IWebElement row)
        {
            _row = row;
        }

        private IEnumerable<IWebElement> _cells => _row.FindElements(By.CssSelector("td"));

        public string ValueInColumn(int columnIndex)
        {
            var hasThatManyCells = _cells.Count() >= columnIndex + 1;
            if (!hasThatManyCells)
            {
                new IndexOutOfRangeException("Table does not have that many columns.");
            }

            return _cells.ElementAt(columnIndex).Text;
        }

        public void scrollIntoView() 
        {
            var actions = new Actions(UITestContext.Driver);
            actions.MoveToElement(_row);
            actions.Build().Perform();
        }

        public bool IsVisible => _row.Displayed;
        public bool IsFullyInView
        {
            get
            {
                var location = _row.Location;
                var scriptRow = "return arguments[0].getBoundingClientRect().bottom + " +
                    "arguments[0].scrollHeight";

                var scriptViewPort = "return window.scrollY + window.innerHeight";

                var rowBottomLocation =(Int64) ((IJavaScriptExecutor)UITestContext.Driver).ExecuteScript(scriptRow, _row);
                var viewPortBottom = (Int64)((IJavaScriptExecutor)UITestContext.Driver).ExecuteScript(scriptViewPort);

                var isRowWithingViewPortBounds = rowBottomLocation < viewPortBottom;

                return isRowWithingViewPortBounds;
            }
        }
    }
}
