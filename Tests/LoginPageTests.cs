using PageObjects;
using NUnit.Framework;
using Infrastructure;

namespace Tests
{
    public class Tests : BaseUITestTemplate
    {
        [Test]
        public void GivenLoginForm_WhenUserNameIsWrong_DisplayErrorMessage()
        {
            var testData =  new {
                invalidUsername = "Invalid Username",
                invalidPassword = "Invalid Password"
            };

            TestSteps()
                .GoTo<LoginPageObject>((p, a) => a
                .Set(p.UserName, testData.invalidUsername)
                .Set(p.Password, testData.invalidPassword)
                .Click(p.LoginButton))
            .AwaitPageLoad<LoginPageObject>((p, a) => a
                .Assert(that => that
                    .PageUrl(Is.EqualTo(p.Url))
                    .ErrorMessageWasDisplayed()
                    .Field(p.UserName, Is.Empty)));
        }
    }
}