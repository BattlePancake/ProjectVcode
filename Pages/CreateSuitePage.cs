using ProjectVcode.Elements;
using OpenQA.Selenium;

namespace ProjectVcode.Pages
{
    internal class CreateSuitePage : BasePage
    {
        public static Element _titleField = new(By.XPath("//*[@id='title']"));



        public static void ClickOnElement(Element element) => element.ClickElement();
    }
}
