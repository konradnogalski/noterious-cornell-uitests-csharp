using OpenQA.Selenium;

namespace Infrastructure
{    
    public interface IPageObject {
        string Url {get; }
        bool HasErrors();
    }
}