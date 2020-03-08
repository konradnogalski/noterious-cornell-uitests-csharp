using Infrastructure.PageObject;
using Infrastructure.PageObject.PageElements;
using OpenQA.Selenium;

namespace PageObjects
{
    public class ExamplesPage : PageObject
    {
        private string _loginPageUrl = "https://noterious-cornell-dev.herokuapp.com/examples";

        public ExamplesPage(IWebDriver driver) : base(driver)
        {
            Form = new WebElement(driver, By.CssSelector(".parent"));
            FirstInputElement = new WebElement(Form, By.CssSelector(".child:first-child"));
            SecondChild = new WebElement(Form, By.CssSelector(".child:nth-child(2)"));
            SecondChild = new WebElement(Form, By.CssSelector(".child:last-child"));
        }

        public WebElement Form { get; private set; }
        public WebElement FirstInputElement { get; private set; }
        public WebElement SecondChild { get; private set; }
        public WebElement ThirdChild { get; private set; }

        public override string Url => _loginPageUrl;
    }
}
