using ProjectVcode.Elements;
using OpenQA.Selenium;
using ProjectVcode.Models;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;

namespace ProjectVcode.Pages
{
    internal class InProjectPage : BasePage
    {
        public static Element _notificationsButton = new(By.XPath("//*[@aria-label='Notifications']//div"));

        public static Element _createCaseButton = new(By.XPath("//*[@id='create-case-button']"));
        public static Element _createSuiteButton = new(By.XPath("//*[@id='create-suite-button']"));

        public static Element _deleteCaseButton = new(By.XPath("//*[@class='d-flex VyDjOX']//button[4]"));
        public static Element _deleteCaseConfirmationField = new(By.XPath("//*[@class='form-control DcqLJ3']"));
        public static Element _deleteCaseConfirmationButton = new(By.XPath("//*[@class='pfDFL9']//button[2]"));

        public static void CreateSuite(Suite testSuite)
        {
            ClickOnElement(_createSuiteButton);
            
        }

        public static void CreateCase(Case testCase)
        {
            ClickOnElement(_createCaseButton);
            CreateCasePage.FillTheForm(testCase.CaseName);
            CreateCasePage.CLickSaveButton();
        }
        public static void ClickCreateCaseButton() => ClickOnElement(_createCaseButton);

        public static Element FindCaseCheckbox(int id)
            => new(By.XPath($"//*[@id='suitecases-container']//div//div//div//div[{id}]//div//div//div[1]//span//input"));
        public static void DeleteCase(int id)
        {
            ClickOnElement(FindCaseCheckbox(id));
            ClickOnElement(_deleteCaseButton);
            _deleteCaseConfirmationField.SendValue("CONFIRM");
            ClickOnElement(_deleteCaseConfirmationButton);
            ClickOnElement(_notificationsButton);  //  Добавлено для того, чтобы анимация удаления кейса успела сработать и
            ClickOnElement(_notificationsButton);  //  метод CheckCaseDeleted искал уже удалённый кейс (вместо thread.sleep)
        }

        public static bool CheckNoCaseExisting(Case testCase)
        {
            try
            {
                var v = GetCaseName(testCase.CaseId);
            }
            catch (OpenQA.Selenium.WebDriverTimeoutException ex)
            {
                return false;
            }
            return true;
        }

        public static Element CaseName(int id) 
            => new(By.XPath($"//*[@id='suitecases-container']//div//div//div//div[{id}]//div//div//div[5]"));
        public static string GetCaseName(int id) => GetTheElementText(CaseName(id));


        public static Element ProjectNamesTitles(string name) => new(By.XPath($"//*[text()='{name}']"));
        public static bool CheckProjectNames(Project project)
        {
            if(ProjectNamesTitles(project.ProjectName).GetElementText() == project.ProjectName 
                && ProjectNamesTitles(project.ProjectCode).GetElementText().Contains(project.ProjectCode))
                return true;
            else
                return false;
        }

        public static void ClickOnElement(Element element) => element.ClickElement();
        public static string GetTheElementText(Element element) => element.GetElementText();
    }
}
