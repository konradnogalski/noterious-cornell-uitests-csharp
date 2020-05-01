using System;
using Infrastructure.PageObject.PageElements;
using Infrastructure.PageObject.PageElements.Interfaces;

namespace Infrastructure.FluentTestSteps
{
    public class PageFluentActions<TCurrentPageObject> where TCurrentPageObject : IPageObject
    {
        private TCurrentPageObject _pageObject;
        public PageFluentActions(TCurrentPageObject pageObject)
        {
            _pageObject = pageObject;
        }

        public PageFluentActions<TCurrentPageObject> Expect(Action<PageFluentAsserts> fluentAsserts){
            fluentAsserts.Invoke(new PageFluentAsserts(_pageObject));

            return this;
        }
        public PageFluentActions<TCurrentPageObject> Set(ISetable setablePageElement, string value){
            setablePageElement.Set(value);

            return this;
        }

        public PageFluentActions<TCurrentPageObject> Click(IClickable clickablePageElement){
            clickablePageElement.Click();

            return this;
        }

        public PageFluentActions<TCurrentPageObject> InTable<TCurrentTable>(TCurrentTable table, Action<TableFluentActions<TCurrentTable>> tableActions)
         where TCurrentTable : Table
        {
            tableActions.Invoke(new TableFluentActions<TCurrentTable>(table));
            return this;
        }
    }
}
