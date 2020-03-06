using OpenQA.Selenium;

namespace Infrastructure
{    
    public interface IPageObject {
        string Url {get; }
        IWebElement FindElement(By elementFinder);
        bool HasErrors();
    }
}