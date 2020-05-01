using System;
using OpenQA.Selenium;

namespace Infrastructure
{
    public class UITestContext : IDisposable
    {
        public UITestContext(IWebDriver driver)
        {
            Driver = driver;
        }

        public IWebDriver Driver { get; private set; }       

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