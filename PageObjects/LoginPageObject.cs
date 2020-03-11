using Infrastructure.PageObject.PageElements;
using OpenQA.Selenium;

namespace PageObjects
{

    public class LoginPage : UsernamePassowrdLoginPageObject
    {
        private string _loginPageUrl = "login";
        private string _loginButtonCssSelector = "button";
        private string _googleLoginButtonCssSelector = "a[href='/auth/google']";
        private string _registerLinkCssSelector = "a[href='/register']";

        public LoginPage(IWebDriver driver) : base(driver)
        {
            LoginButton = new Button(new WebElement(Driver, By.CssSelector(_loginButtonCssSelector)));
            GoogleLoginButton = new Button(new WebElement(Driver, By.CssSelector(_googleLoginButtonCssSelector)));
            RegisterLink = new Button(new WebElement(Driver, By.CssSelector(_registerLinkCssSelector)));
        }

        public override string RelativeUrl => _loginPageUrl;
        public Button LoginButton { get; private set; }
        public Button GoogleLoginButton { get; private set; }
        public Button RegisterLink { get; private set; }
    }
}