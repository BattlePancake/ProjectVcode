using ProjectVcode.Elements;
using OpenQA.Selenium;
using ProjectVcode.Models;
using ProjectVcode.Constants;

namespace ProjectVcode.Pages
{
    internal class CreateCasePage : BasePage
    {
        public static Element _titleField = new(By.XPath("//*[@id='title']"));

        public static Element _saveButton = new(By.XPath("//*[@class='WIIq1A']//button[1]"));
        public static Element _cancelButton = new(By.XPath("//*[@class='WIIq1A']//button[3]"));
        public static Element _closeFormButton = new(By.XPath("//*[@class='pfDFL9']//button[2]"));

        public static Element _statusDropdown = new(By.XPath("//*[@class='col-xl-4 col-lg-4 col-md-12 col-sm-12 form-group']//div[2]"));
        public static Element ChooseStatus(string name) => new(By.XPath($"//*[text()='{name}']"));
        //public static Element _actualStatus = new(By.XPath("//*[text()='Actual']"));



        public static void FillTheForm(string title/*, string status*/)
        {
            _titleField.SendValue(title);
            /*ClickOnElement(_statusDropdown);
            ClickOnElement(ChooseStatus(status));*/
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
