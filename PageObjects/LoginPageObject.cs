using Infrastructure;
using Infrastructure.PageElements;
using OpenQA.Selenium;

namespace PageObjects
{
    public class LoginPageObject : PageObject
    {
        private string _loginPageUrl = "https://noterious-cornell-dev.herokuapp.com/login";
        private string _usernameFieldDisplayName = "Username";
        private string _usernameFieldId = "inputUsername";
        private string _passwordFieldDisplayName = "Password";
        private string _passwordFieldId = "inputPassword";
        private string _loginButtonDisplayName = "Login";
        private string _loginButtonCssSelector = "button";
        private string _googleloginButtonDisplayName = "Google";
        private string _googleLoginButtonACssSelector = "a[href='/auth/google']";
        private string _registerLinkDisplayName = "Click here to create one";
        private string _registerLinkCssSelector = "a[href='/register']";
        public TextField UserName => new TextField(By.Id(_usernameFieldId), _usernameFieldDisplayName);
        public TextField Password => new TextField(By.Id(_passwordFieldId), _passwordFieldDisplayName);
        public Button LoginButton => new Button(By.CssSelector(_loginButtonCssSelector), _loginButtonDisplayName);
        public Button GoogleLogin => new Button(By.CssSelector(_googleLoginButtonACssSelector), _googleloginButtonDisplayName);
        public Button RegisterLink => new Button(By.CssSelector(_registerLinkCssSelector), _registerLinkDisplayName);
        public override string Url => _loginPageUrl;
    }
}
