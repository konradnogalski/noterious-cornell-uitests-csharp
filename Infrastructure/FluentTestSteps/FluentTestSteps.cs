using OpenQA.Selenium;
using System;

namespace Infrastructure.FluentTestSteps
{
    public class FluentTestSteps
    {
        private readonly IWebDriver _driver;
        public FluentTestSteps(IWebDriver driver)
        {
            _driver = driver;
        }

        public FluentTestSteps GoTo<TCurrentPageObject>(Action<TCurrentPageObject, PageFluentActions<TCurrentPageObject>> pageActions)
         where TCurrentPageObject : IPageObject
        {
            LoadPage(true, pageActions);

            return this;
        }  

        public FluentTestSteps AwaitPageLoad<TCurrentPageObject>(Action<TCurrentPageObject, PageFluentActions<TCurrentPageObject>> pageActions)
         where TCurrentPageObject : IPageObject
        {
            LoadPage(false, pageActions);

            return this;
        }

        private FluentTestSteps LoadPage<TCurrentPageObject>(bool shouldNavigateToPage, Action<TCurrentPageObject, PageFluentActions<TCurrentPageObject>> pageActions, Action beforePageLoadAction = null)
         where TCurrentPageObject : IPageObject
        {
            var pageObject = CreatePageObject<TCurrentPageObject>();
            if (shouldNavigateToPage)
            {
                
                _driver.Navigate().GoToUrl(
                    $"{Configuration.Settings.Protocol}://{Configuration.Settings.Host}/{pageObject.RelativeUrl}");
            }

            pageActions.Invoke(pageObject, new PageFluentActions<TCurrentPageObject>(pageObject));

            return this;
        }

        private TCurrentPageObject CreatePageObject<TCurrentPageObject>()
            where TCurrentPageObject : IPageObject
        {
            return (TCurrentPageObject)Activator.CreateInstance(typeof(TCurrentPageObject), new[] { _driver });
        }      
    }
}