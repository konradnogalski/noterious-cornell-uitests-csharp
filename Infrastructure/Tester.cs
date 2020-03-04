using System;
using OpenQA.Selenium;

namespace Infrastructure
{
     public class Tester
     {
      public static void NavigateTo<TCurrentPageObject>(Action<TCurrentPageObject, FluentPageActions<TCurrentPageObject>> pageActions)
         where TCurrentPageObject : PageObject, new()
      {

            var pageObject = new TCurrentPageObject();
            UITestContext.Driver.Navigate().GoToUrl(pageObject.Url);

            var script = "return document.readyState";
            ((IJavaScriptExecutor)UITestContext.Driver).ExecuteScript(script).Equals("complete");

            pageActions.Invoke(pageObject, new FluentPageActions<TCurrentPageObject>(pageObject));
        }       
     }
}