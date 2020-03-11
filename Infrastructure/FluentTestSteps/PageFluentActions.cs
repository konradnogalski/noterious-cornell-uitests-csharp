using System;
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

        public PageFluentActions<TCurrentPageObject> Assert(Action<PageFluentAsserts> fluentAsserts){
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
    }
}
