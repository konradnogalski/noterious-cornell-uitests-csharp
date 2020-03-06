using System;

namespace Infrastructure.FluentTestSteps
{
    public class TestSteps
    {
        private UITestContext _uiTestContext;
        public TestSteps(UITestContext uiTestContext)
        {
            _uiTestContext = uiTestContext;
        }
        public TestSteps GoTo<TCurrentPageObject>(Action<TCurrentPageObject, FluentPageActions<TCurrentPageObject>> pageActions)
         where TCurrentPageObject : IPageObject
        {
            LoadPage(true, pageActions);

            return this;
        }  

        public TestSteps AwaitPageLoad<TCurrentPageObject>(Action<TCurrentPageObject, FluentPageActions<TCurrentPageObject>> pageActions)
         where TCurrentPageObject : IPageObject
        {
            LoadPage(false, pageActions);

            return this;
        }

        private TestSteps LoadPage<TCurrentPageObject>(bool shouldNavigatePage, Action<TCurrentPageObject, FluentPageActions<TCurrentPageObject>> pageActions, Action beforePageLoadAction = null)
         where TCurrentPageObject : IPageObject
        {
            var pageObject = CreatePageObject<TCurrentPageObject>();
            if (shouldNavigatePage)
            {
                _uiTestContext.NavigateTo(pageObject.Url);
            }

            _uiTestContext.AwaitPageLoad();
            pageActions.Invoke(pageObject, new FluentPageActions<TCurrentPageObject>(pageObject));

            return this;
        }

        private TCurrentPageObject CreatePageObject<TCurrentPageObject>()
            where TCurrentPageObject : IPageObject
        {
            return (TCurrentPageObject)Activator.CreateInstance(typeof(TCurrentPageObject), new[] { _uiTestContext.Driver });
        }      
    }
}