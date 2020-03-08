using System;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Infrastructure
{
    public class UITestContext
    {
        private readonly string ScreenshotsDirectory = "Screenshots";
        public IWebDriver Driver {get; private set;}
        public UITestContext(IWebDriver driver)
        {
            Driver = driver;
        }

        public void NavigateTo(string url)
        {
            Driver.Navigate().GoToUrl(url);
        }

        public void AwaitPageLoad()
        {
            ((IJavaScriptExecutor)Driver).ExecuteScript("return document.readyState").Equals("complete");
        }

        public void CleanUp()
        {
            if (IsTestFailed()){
                TakeScreenShot();
            }
            
            Driver.Quit();    
        }

        public bool IsTestFailed()
        {
            return TestContext.CurrentContext.Result.FailCount > 0;
        }
        public void TakeScreenShot()
        {
             var screenShot = ((ITakesScreenshot)Driver).GetScreenshot();
            screenShot.SaveAsFile($@"{ScreenshotsDirectory}\Screenshot-{DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss")}.png");
        }
    }
}