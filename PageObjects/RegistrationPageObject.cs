using Infrastructure.PageObject.PageElements;
using OpenQA.Selenium;

namespace PageObjects
{
    public class RegistrationPage : UsernamePassowrdLoginPageObject
    {
        private string _registerPageUrl = "register";
        private string _registerButtonCssSelector = "button";
        private string _passwordConfirmationFieldId = "inputPasswordConfirm";

        public RegistrationPage(IWebDriver driver) : base(driver)
        {
            RegisterButton = new Button(Driver, By.CssSelector(_registerButtonCssSelector));
            ConfirmPassword = new TextField(Driver, By.Id(_passwordConfirmationFieldId));
        }

        public override string RelativeUrl => _registerPageUrl;
        public Button RegisterButton { get; private set; }
        public TextField ConfirmPassword { get; private set; }
    }
}