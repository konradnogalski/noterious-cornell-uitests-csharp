using System;
using OpenQA.Selenium;

namespace Infrastructure
{
    public static class UITestContext
    {
        public static IWebDriver Driver { get; private set; }
        public static void Create(IWebDriver driver)
        {
            Driver = driver;
        }
        public static void Dispose()
        {
            if (Driver != null)
            {
                Driver.Quit();
                Driver = null;
            }
        }
    }
}