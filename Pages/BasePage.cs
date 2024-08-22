using OpenQA.Selenium;
using ProjectVcode.Factory;

namespace ProjectVcode.Pages
{
    internal abstract class BasePage
    {
        protected static IWebDriver driver => Driver.GetDriver();

        public static void OpenPage()
        {
            Driver.GetDriver().Navigate().GoToUrl("https://app.qase.io/login");
        }
    }
}