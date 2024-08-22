using ProjectVcode.Elements;
using OpenQA.Selenium;

namespace ProjectVcode.Pages
{
    internal class CreateCasePage : BasePage
    {
        private static Element _titleField = new(By.XPath("//*[@id='title']"));

        private static Element _saveButton = new(By.XPath("//*[@class='WIIq1A']//button[1]"));
        private static Element _cancelButton = new(By.XPath("//*[@class='WIIq1A']//button[3]"));
        private static Element _closeFormButton = new(By.XPath("//*[@class='pfDFL9']//button[2]"));

        public static Element ChooseStatus(string name) => new(By.XPath($"//*[text()='{name}']"));

        public static void FillTheForm(string title)
        {
            _titleField.SendValue(title);
        }

        public static void CancelTheForm()
        {
            ClickOnElement(_cancelButton);
            ClickOnElement(_closeFormButton);
        }
        public static void CLickSaveButton() => ClickOnElement(_saveButton);

        public static void ClickOnElement(Element element) => element.ClickElement();
    }
}
