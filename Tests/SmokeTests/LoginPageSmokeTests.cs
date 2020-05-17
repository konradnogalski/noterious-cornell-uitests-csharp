using System;
using PageObjects;
using Infrastructure;

using Infrastructure.PageObject.PageElements;
using Infrastructure.PageObject.PageElements.Interfaces;

namespace Tests
{
    public class LoginPageSmokeTests : TestFixtureBase
    {
        [Test]
        public void SetUserName()
        {
            var testUserName = "username";
            SetTextFieldSmokeTest((p) => p.UserName, testUserName);
        }

        [Test]
        public void SetPassword()
        {
            var testPassword = "password";
            SetTextFieldSmokeTest((p) => p.Password, testPassword);
        }
  
        [Test]
        public void ClickLoginButton()
        {
            ClickSmokeTest((p) => p.LoginButton);
        }

        [Test]
        public void ClickGoogleButton()
        {
            ClickSmokeTest((p) => p.GoogleLoginButton);
        }

        [Test]
        public void ClickRegisterLink()
        {
            ClickSmokeTest((p) => p.RegisterLink);
        }

        private void SetTextFieldSmokeTest(Func<LoginPage, TextField> textFieldSpecifier, string value)
        {
            TestSteps.
                GoTo<LoginPage>((p, a) =>
                {
                    var textField = textFieldSpecifier.Invoke(p);
                    a.Set(textFieldSpecifier.Invoke(p), value)
                        .Expect(that => that
                            .Field(textFieldSpecifier.Invoke(p), Is.EqualTo(value)));
                });
        }

        private void ClickSmokeTest(Func<LoginPage, IClickable> buttonSpecifier)
        {
            TestSteps.
                GoTo<LoginPage>((p, a) => a
                    .Click(buttonSpecifier(p)));
        }
    }
}
