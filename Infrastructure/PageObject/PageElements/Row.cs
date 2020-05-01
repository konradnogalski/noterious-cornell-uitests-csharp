using OpenQA.Selenium;
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
    }
}
