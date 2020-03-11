using System;

namespace Infrastructure.FluentTestSteps
{
    public class FluentTestSteps
    {
        private readonly UITestContext _uiTestContext;
        public FluentTestSteps(UITestContext uiTestContext)
        {
            _uiTestContext = uiTestContext;
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

        private FluentTestSteps LoadPage<TCurrentPageObject>(bool shouldNavigatePage, Action<TCurrentPageObject, PageFluentActions<TCurrentPageObject>> pageActions, Action beforePageLoadAction = null)
         where TCurrentPageObject : IPageObject
        {
            var pageObject = CreatePageObject<TCurrentPageObject>();
            if (shouldNavigatePage)
            {
                _uiTestContext.NavigateTo(pageObject.RelativeUrl);
            }

            pageActions.Invoke(pageObject, new PageFluentActions<TCurrentPageObject>(pageObject));

            return this;
        }

        private TCurrentPageObject CreatePageObject<TCurrentPageObject>()
            where TCurrentPageObject : IPageObject
        {
            return (TCurrentPageObject)Activator.CreateInstance(typeof(TCurrentPageObject), new[] { _uiTestContext.Driver });
        }      
    }
}