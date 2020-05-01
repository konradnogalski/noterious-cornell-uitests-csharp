using Infrastructure.PageObject.PageElements;
using Infrastructure.PageObject;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace PageObjects
{
    public abstract class UsernamePassowrdLoginPageObject : PageObject, IHasErrorsPage
    {
        private string _usernameFieldId = "inputUsername";
        private string _passwordFieldId = "inputPassword";


        public UsernamePassowrdLoginPageObject(IWebDriver driver) : base(driver)
        {
            UserName = new TextField(Driver, By.Id(_usernameFieldId));
            Password = new TextField(Driver, By.Id(_passwordFieldId));
        }

        public TextField UserName { get; private set; }
        public TextField Password { get; private set; }

        public List<string> Errors => 
            Driver.FindElements(By.CssSelector(".invalid-feedback"))
                .Where(e => e.GetCssValue("display") != "none")
                .Select(e => e.Text).ToList();
    }
}