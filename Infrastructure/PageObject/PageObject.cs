using OpenQA.Selenium;

namespace Infrastructure.PageObject
{
    public abstract class PageObject : IPageObject
    {
        protected IWebDriver Driver;     
        public PageObject(IWebDriver driver)
        {
            Driver = driver;
        }

        public abstract string RelativeUrl {get; }
    }
}
