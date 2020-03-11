using PageObjects;
using NUnit.Framework;
using Infrastructure;
using NUnit.Framework.Internal;
using System;

namespace Tests
{
    public class RegisterPageTests : TestFixtureBase
    {
        
        [Test]
        public void GivenRegisterForm_WhenRegisterButtonPressed_UserIsNotRegistered()
        {
            TestSteps
                .GoTo<RegistrationPage>((p, a) => a
                    .Click(p.RegisterButton)
                    .Assert(that => that
                        .PageUrl(Is.EqualTo(p.RelativeUrl))));
        }

        [Test]
        public void GivenRegisterFormWithOnlyUsernameFilled_WhenRegisterButtonPressed_UserIsNotRegistered()
        {
            var testData = new
            {
                Username = CreateRandomUserName(),
            };

            TestSteps
                .GoTo<RegistrationPage>((p, a) => a
                    .Set(p.UserName, CreateRandomUserName())
                    .Click(p.RegisterButton)
                    .Assert(that => that
                        .PageUrl(Is.EqualTo(p.RelativeUrl))));
        }

        [Test]
        public void GivenRegisterFormWithConfirmPasswordEmpty_WhenRegisterButtonPressed_ErrorMessageIsDisplayed()
        {
            var testData = new
            {
                Username = CreateRandomUserName(),
                Password = "p", 
                ExpectedErrorMassage = "Passwords don't match"
            };

            TestSteps
                .GoTo<RegistrationPage>((p, a) => a
                    .Set(p.UserName, testData.Username)
                    .Set(p.Password, testData.Password)
                    .Click(p.RegisterButton)
                    .Assert(that => that
                        .PageUrl(Is.EqualTo(p.RelativeUrl))
                        .HasErrors()
                        .ErrorsContains(testData.ExpectedErrorMassage)));
        }

        [Test]
        public void GivenRegisterFormWithDifferentPassword_WhenRegisterButtonPressed_ErrorMessageIsDisplayed()
        {
            var testData = new
            {
                Username = CreateRandomUserName(),
                Password = "password",
                ConfirmPassword = "different",
                ExpectedErrorMassage = "Passwords don't match"
            };

            TestSteps
                .GoTo<RegistrationPage>((p, a) => a
                    .Set(p.UserName, testData.Username)
                    .Set(p.Password, testData.Password)
                    .Set(p.ConfirmPassword, testData.ConfirmPassword)
                    .Click(p.RegisterButton)
                    .Assert(that => that
                        .PageUrl(Is.EqualTo(p.RelativeUrl))
                        .HasErrors()
                        .ErrorsContains(testData.ExpectedErrorMassage)));
        }

        [Test]
        public void GivenRegisterFormFilledCorrectly_ShouldNotDisplayErrorMessage()
        {
            var testData = new
            {
                Username = CreateRandomUserName(),
                Password = "password",
                ConfirmPassword = "password",
            };

            TestSteps
                .GoTo<RegistrationPage>((p, a) => a
                    .Set(p.UserName, testData.Username)
                    .Set(p.Password, testData.Password)
                    .Set(p.ConfirmPassword, testData.ConfirmPassword)
                    .Assert(that => that
                        .PageUrl(Is.EqualTo(p.RelativeUrl))
                        .HasNoErrors()));
        }

        [Test]
        public void GivenRegisterFormFilledCorrectly_WhenPasswordChanged_ShouldDisplayErrorMessage()
        {
            var testData = new
            {
                Username = CreateRandomUserName(),
                Password = "password",
                NewPassword = "swordpass",
                ConfirmPassword = "password",
                ExpectedErrorMassage = "Passwords don't match"
            };

            TestSteps
                .GoTo<RegistrationPage>((p, a) => a
                    .Set(p.UserName, testData.Username)
                    .Set(p.Password, testData.Password)
                    .Set(p.ConfirmPassword, testData.ConfirmPassword)
                    .Set(p.Password, testData.NewPassword)
                    .Click(p.RegisterButton)
                    .Assert(that => that
                        .PageUrl(Is.EqualTo(p.RelativeUrl))
                        .HasErrors()
                        .ErrorsContains(testData.ExpectedErrorMassage)));
        }

        [Test]
        public void GivenRegisterFormFilledCorrectly_WhenRegisterButtonIsClicked_ShouldDisplayLoginPage()
        {
            var testData = new
            {
                Username = CreateRandomUserName(),
                Password = "password",
                ConfirmPassword = "password",
            };

            TestSteps
                .GoTo<RegistrationPage>((p, a) => a
                    .Set(p.UserName, testData.Username)
                    .Set(p.Password, testData.Password)
                    .Set(p.ConfirmPassword, testData.ConfirmPassword)
                    .Click(p.RegisterButton))
                .AwaitPageLoad<LoginPage>((p, a) => a
                    .Assert(that => that
                        .PageUrl(Is.EqualTo(p.RelativeUrl))
                        .HasNoErrors()));
        }

        private string CreateRandomUserName()
        {
            return Guid.NewGuid().ToString();
        }
    }
}