using System;
using System.Threading;
using Infrastructure;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using PageObjects;

namespace Tests
{
    public class Tests : BaseUITest
    {
        private IWebDriver test1driver;
        private IWebDriver test2driver;

        [Test]
        public void GivenLoginForm_WhenUserNameIsWrong_DisplayErrorMessage()
        {
            var testData =  new {
                invalidUsername = "Invalid Username",
                invalidPassword = "Invalid Password"
            };

            Tester.NavigateTo<LoginPageObject>((p, a) => a
                .Set(p.UserName, testData.invalidUsername)
                .Set(p.Password, testData.invalidPassword)
                .Click(p.LoginButton)
                .Assert(that => that
                    .PageUrl(Is.EqualTo(p.Url))
                    .ErrorMessageWasDisplayed()
                    .Field(p.UserName, Is.Empty)));
        }
    }
}