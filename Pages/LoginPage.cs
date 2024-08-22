using ProjectVcode.Elements;
using ProjectVcode.Models;
using OpenQA.Selenium;
using ProjectVcode.Constants;

namespace ProjectVcode.Pages
{
    internal class LoginPage : BasePage
    {
        private static Element _emailField = new Element(By.XPath("//*[@name='email']"));
        private static Element _passwordField = new(By.XPath("//*[@name='password']"));
        private static Element _signInButton = new(By.XPath("//*[@type='submit']"));

        private static Element _welcomeText = new(By.XPath("//*[@class='EVJZpv']"));

        private static Element _requiredErrorEmailField = new(By.XPath("//*[@class='_0CVzo']//div[1]//small"));
        private static Element _requiredErrorPassField = new(By.XPath("//*[@class='_0CVzo']//div[2]//small"));

        private static Element _popUpErrorMessage = new(By.XPath("//*[@class='litzGK']//div[1]//span//span"));

        public static bool WrongFormatErrorText(string email)
        {
            if(GetTheElementText(_popUpErrorMessage).Equals($"{Consts.ErrorMessage1}'{email}'{Consts.ErrorMessage2}"))
                return true;
            else
                return false;
        }
        public static bool InvalidCredentialsErrorText()
        {
            if (GetTheElementText(_popUpErrorMessage) == Consts.InvalidCredentialsError)
                return true;
            else
                return false;
        }
        public static bool RequiredEmailErrorText()
        {
            if (GetTheElementText(_requiredErrorEmailField) == Consts.LoginFieldsRequiredError)
                return true;
            else
                return false;
        }
        public static bool RequiredPassErrorText()
        {
            if (GetTheElementText(_requiredErrorPassField) == Consts.LoginFieldsRequiredError)
                return true;
            else
                return false;
        }
        public static bool RequiredEmailErrorExisting()
        {
            try
            {
                var emailError = GetTheElementText(_requiredErrorEmailField);
            }
            catch (OpenQA.Selenium.WebDriverTimeoutException)
            {
                return false;
            }
            return true;
        }
        public static bool RequiredPassErrorExisting()
        {
            try
            {
                var passError = GetTheElementText(_requiredErrorPassField);
            }
            catch (OpenQA.Selenium.WebDriverTimeoutException)
            {
                return false;
            }
            return true;
        }

        public static void FastLogin(string email, string pass)
        {
            User user = new User(email, pass);
            LoginPage.Login(user);
        }
        public static void Login(User user)
        {
            _emailField.SendValue(user.Name);
            _passwordField.SendValue(user.Password);
            ClickOnElement(_signInButton);
        }
        public static bool CheckUserLoggedOut()
        {
            try
            {
                var v = GetTheElementText(_welcomeText);
            }
            catch (OpenQA.Selenium.WebDriverTimeoutException ex)
            {
                return false;
            }
            return true;
        }

        public static void ClickOnElement(Element element) => element.ClickElement();
        public static string GetTheElementText(Element element) => element.GetElementText();
    }
}