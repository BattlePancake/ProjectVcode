using ProjectVcode.Elements;
using OpenQA.Selenium;
using ProjectVcode.Models;

namespace ProjectVcode.Pages
{
    internal class ProjectsPage : BasePage
    {
        private static Element _loadedText = new(By.XPath("//*[@class='P3tqoY']//th[3]//div//div"));
        
        private static Element _statusSortButton = new(By.XPath("//*[@class='i1gltl']//div//div//div[2]"));

        private static Element _deleteProjectButton = new(By.XPath("//*[text()='Remove']"));
        private static Element _deleteProjectConfirmationButton = new(By.XPath("//*[@class='Wuj713']//button[2]"));

        public static Element _createNewProjectButton = new(By.XPath("//*[@id='createButton']"));
        public static Element ProjectNameTitle(string name) => new(By.XPath($"//*[text()='{name}']"));
        public static void ChooseProjectByName(string name) => ClickOnElement(ProjectNameTitle(name));
        public static bool CheckProjectExists(Project project)
        {
            try
            {
                bool v = ProjectNameTitle(project.ProjectName).GetElementText() == project.ProjectName;
            }
            catch (OpenQA.Selenium.WebDriverTimeoutException ex)
            {
                return false;
            }
            return true;
        }

        public static Element ProjectNumberThreeDot(int number) => new(By.XPath($"//*[@class='YtumFo']//tr[{number}]//td[8]//button"));
        public static void DeleteProject(int num)
        {
            ProjectNumberThreeDot(num).ClickElement();
            ClickOnElement(_deleteProjectButton);
            ClickOnElement(_deleteProjectConfirmationButton);
            ClickOnElement(_statusSortButton);  //  animation
        }

        public static bool CheckPageLoaded()
        {
            try
            {
                var v = GetTheElementText(_loadedText);
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
