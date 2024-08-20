using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;

namespace ProjectVcode.Factory
{
    internal class Driver
    {
        private static IWebDriver? _driver;
        private static WebDriverWait? _wait;

        public static WebDriverWait GetWait(IWebDriver driver, double waitTime = 10) =>
            _wait ??= new(_driver, TimeSpan.FromSeconds(waitTime));
        public static IWebDriver GetDriver() => _driver ??= SetupDriver();
        public static void QuitDriver()
        {
            _driver?.Quit();
            _driver = null;
            _wait = null;
        }

        private static IWebDriver SetupDriver() => new ChromeDriver(GetOptions());

        private static ChromeOptions GetOptions()
        {
            var options = new ChromeOptions();
            options.AddArgument("start-maximized");
            return options;
        }
    }
}
