using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using ProjectVcode.Factory;

namespace ProjectVcode.Elements
{
    internal class Element
    {
        private readonly By? _locator;
        private Actions actions = new Actions(Driver.GetDriver());

        public Element(By locator) => _locator = locator;

        public IWebElement FindWebElement
        {
            get
            {
                WaitWebElementPresent();
                return Driver.GetDriver().FindElement(_locator);
            }
        }

        public void WaitWebElementPresent() => Driver.GetWait(Driver.GetDriver()).Until(drv =>
        drv.FindElements(_locator).Count() > 0);

        public void SendValue(string value)
        {
            ScrollToElement();
            FindWebElement.SendKeys(value);
        }

        public void ClickElement()
        {
            ScrollToElement();
            FindWebElement.Click();
        }

        public string GetElementAttribute(string atr) => FindWebElement.GetAttribute(atr);

        public void ScrollToElement() => actions.MoveToElement(FindWebElement);

        public string GetElementText() => FindWebElement.Text;

        public void ClearField()
        {
            for(int a = 0; a < 10; a++)
            {
                FindWebElement.SendKeys(Keys.Backspace);
            }
        }
    }
}