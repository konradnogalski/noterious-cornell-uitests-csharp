using System;
using OpenQA.Selenium;

namespace Infrastructure
{
    public class FluentPageActions<IPageObject> where IPageObject : PageObject
    {
        private IPageObject _pageObject;
        public FluentPageActions(IPageObject pageObject)
        {
            _pageObject = pageObject;
        }

        public FluentPageActions<IPageObject> Assert(Action<FluentAsserts> fluentAsserts){
            fluentAsserts.Invoke(new FluentAsserts());

            return this;
        }
        public FluentPageActions<IPageObject> Set(ISetable setablePageElement, string value){
            setablePageElement.Set(value);

            return this;
        }

        public FluentPageActions<IPageObject> Click(IClickable clickablePageElement){
            clickablePageElement.Click();

            return this;
        }
    }


  

   
    
    

    public interface IClickable{
        void Click();
    }

    public interface ISetable{
        void Set(string value);
        string Value { get; }
    }
}
