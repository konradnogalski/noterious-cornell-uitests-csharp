using OpenQA.Selenium;

namespace Infrastructure.PageObject
{
    public abstract class PageObject : IPageObject
    {
        private IWebDriver _driver;     
        public PageObject(IWebDriver driver)
        {
            _driver = driver;
        }

        public abstract string Url {get; }
        public IWebElement FindElement(By elementFinder){
             var elements = _driver.FindElements(elementFinder);
            return elements.Count > 0 ? elements[0] : null;
        }

        public bool HasErrors()
        {
            return FindElement(By.CssSelector(".is-invalid")) != null;
        }
    }
}
