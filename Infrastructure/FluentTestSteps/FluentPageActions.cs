using System;
using Infrastructure.PageObject.PageElements.Interfaces;

namespace Infrastructure.FluentTestSteps
{
    public class FluentPageActions<TCurrentPageObject> where TCurrentPageObject : IPageObject
    {
        private TCurrentPageObject _pageObject;
        public FluentPageActions(TCurrentPageObject pageObject)
        {
            _pageObject = pageObject;
        }

        public FluentPageActions<TCurrentPageObject> Assert(Action<PageFluentAsserts> fluentAsserts){
            fluentAsserts.Invoke(new PageFluentAsserts(_pageObject));

            return this;
        }
        public FluentPageActions<TCurrentPageObject> Set(ISetable setablePageElement, string value){
            setablePageElement.Set(value);

            return this;
        }

        public FluentPageActions<TCurrentPageObject> Click(IClickable clickablePageElement){
            clickablePageElement.Click();

            return this;
        }
    }
}
