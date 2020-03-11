using System;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Infrastructure
{
    public class UITestContext : IDisposable
    {
        private ScreenshotTaker _screenshotTaker;

        public UITestContext()
        {
        }

        public void Initialize(string screenshotsDirectory)
        {
            Driver = new ChromeDriver();
            _screenshotTaker = new ScreenshotTaker((ITakesScreenshot)Driver, screenshotsDirectory);
        }

        public IWebDriver Driver { get; private set; }
        
        public void TakeScreenshot()
        {
            _screenshotTaker.TakeScreenshot($@"{TestContext.CurrentContext.Test.MethodName}_{DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss")}.png");
        }  

        public bool IsTestFailed()
        {
            return TestContext.CurrentContext.Result.FailCount > 0;
        }

        public void NavigateTo(string relativeUrl)
        {
            Driver.Navigate().GoToUrl($"{Configuration.Settings.Protocol}://{Configuration.Settings.Host}/{relativeUrl}");
        }

        public void Dispose()
        {
            if (Driver != null)
            {
                Driver.Quit();
                Driver = null;
            }
        }
    }
}