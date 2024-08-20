﻿using ProjectVcode.Pages;
using NUnit.Allure.Core;

namespace ProjectVcode.Tests
{
    [AllureNUnit]
    internal class LoginPageTest : BaseTest
    {
        //[TestCase("breadwithabeard@gmail.com", "ewq1edc2esz3Q!")]

        //[TestCase("vladsivograkovwork@gmail.com", "ewq1edc2esz3!Q")]

        [TestCase("1testprojectv1@gmail.com", "ewq1edc2esz3W!", "3")]
        [Description("Sign in and profile name check - positive test")]
        public void LoginPageTest1(string email, string password, int nameId)
        {
            LoginPage.FastLogin(email, password);
            Assert.That(ProjectsPage.CheckPageLoaded(), Is.True);

            ProfileMenu.NavigateToProfile();
            Assert.That(ProfileMenu.CheckProfileName(nameId), Is.True);
        }

        [TestCase("1testprojectv1@gmail.com", "ewq1edc2esz3W!")]
        [Description("Sign out - positive test")]
        public void LoginPageTest2(string email, string password)
        {
            LoginPage.FastLogin(email, password);
            Assert.That(ProjectsPage.CheckPageLoaded(), Is.True);

            ProfileMenu.SignOut();
            Assert.That(LoginPage.CheckUserLoggedOut(), Is.True);
        }

        [TestCase("", "")]
        [Description("Sign in with both empty fields with error text check - negative test")]
        public void LoginPageTest3(string email, string password)
        {
            LoginPage.FastLogin(email, password);
            Assert.That(LoginPage.CheckUserLoggedOut(), Is.True);

            Assert.That(LoginPage.RequiredEmailErrorText(), Is.True);

            Assert.That(LoginPage.RequiredPassErrorText(), Is.True);
        }

        [TestCase("1testprojectv1@gmail.com", "")]
        [Description("Sign in with empty pass field with error check - negative test")]
        public void LoginPageTest4(string email, string password)
        {
            LoginPage.FastLogin(email, password);
            Assert.That(LoginPage.CheckUserLoggedOut(), Is.True);

            Assert.That(LoginPage.RequiredEmailErrorExisting(), Is.False);

            Assert.That(LoginPage.RequiredPassErrorExisting(), Is.True);
        }

        [TestCase("", "12341234")]
        [Description("Sign in with empty email field with error check - negative test")]
        public void LoginPageTest5(string email, string password)
        {
            LoginPage.FastLogin(email, password);
            Assert.That(LoginPage.CheckUserLoggedOut(), Is.True);

            Assert.That(LoginPage.RequiredEmailErrorExisting(), Is.True);

            Assert.That(LoginPage.RequiredPassErrorExisting(), Is.False);
        }

        [TestCase("1testprojectv11@gmail.com", "ewq1edc2esz3W!1")]
        [Description("Sign in with invalid credentials with pop-up error text check - negative test")]
        public void LoginPageTest6(string email, string password)
        {
            LoginPage.FastLogin(email, password);
            Assert.That(LoginPage.CheckUserLoggedOut(), Is.True);

            Assert.That(LoginPage.InvalidCredentialsErrorText(), Is.True);
        }

        [TestCase("111", "aaa")]
        [Description("Sign in with invalid format credentials with pop-up error text check - negative test")]
        public void LoginPageTest7(string email, string password)
        {
            LoginPage.FastLogin(email, password);
            Assert.That(LoginPage.CheckUserLoggedOut(), Is.True);

            Assert.That(LoginPage.WrongFormatErrorText(email), Is.True);
        }
    }
}