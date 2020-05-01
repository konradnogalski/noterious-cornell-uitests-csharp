using PageObjects;
using NUnit.Framework;
using Infrastructure;

namespace Tests
{
    public class LoginPageTests : TestFixtureBase
    {
        [Test]
        public void GivenLoginForm_WhenUserNameIsWrong_DisplayErrorMessage()
        {
            var testData =  new {
                invalidUsername = "Invalid Username",
                invalidPassword = "Invalid Password"
            };

            TestSteps
                .GoTo<LoginPage>((p, a) => a
                .Set(p.UserName, testData.invalidUsername)
                .Set(p.Password, testData.invalidPassword)
                .Click(p.LoginButton))
            .AwaitPageLoad<LoginPage>((p, a) => a
                .Assert(that => that
                    .PageUrl(Is.EqualTo(p.RelativeUrl))
                    .HasErrors()
                    .Field(p.UserName, Is.Empty)));
        }

        [Test]
        public void GivenLoginForm_WhenUserLogsWithCorrectCredentials_UserIsLoggedIn()
        {
            var testData = new
            {
                validUsername = "silence_dogood",
                validPassword = "franklin"
            };

            TestSteps
                .GoTo<LoginPage>((p, a) => a
                .Set(p.UserName, testData.validUsername)
                .Set(p.Password, testData.validPassword)
                .Click(p.LoginButton))
            .AwaitPageLoad<MainPage>((p, a) => a
                .Assert(that => that
                    .PageUrl(Is.EqualTo(p.RelativeUrl))
                    .LabelDisplayedText(p.SignedInUser.DisplayedText, Is.EqualTo(testData.validUsername))));
        }
    }
}