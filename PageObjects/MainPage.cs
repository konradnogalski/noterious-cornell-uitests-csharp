using Infrastructure.PageObject;
using Infrastructure.PageObject.PageElements;
using OpenQA.Selenium;

namespace PageObjects
{
    public class MainPage : PageObject
    {
        private By _loggedUserLabelSelector = By.CssSelector(".logged-user");
        public MainPage(IWebDriver driver) : base(driver)
        {
            SignedInUser = new Label(driver, _loggedUserLabelSelector);
        }

        public Label SignedInUser { get; private set; }

        public override string RelativeUrl => "/home";
    }
}
