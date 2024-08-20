using OpenQA.Selenium;
using ProjectVcode.Elements;
using ProjectVcode.Models;

namespace ProjectVcode.Pages
{
    internal class NewProjectForm : BasePage
    {
        public static Element _projectNameField = new(By.XPath("//*[@id='project-name']"));
        public static Element _projectCodeField = new(By.XPath("//*[@id='project-code']"));
        public static Element _descriptionField = new(By.XPath("//*[@id='description-area']"));

        public static Element _privateRadioButton = new(By.XPath("//*[text()='Private']"));
        public static Element _publicRadioButton = new(By.XPath("//*[text()='Public']"));
        public static Element _allMembersRadioButton = new(By.XPath("//*[text()='Add all members to this project']"));

        public static Element _groupAccessRadioButton = new(By.XPath("//*[text()='Group access']"));
        public static Element _noMembersRadioButton = new(By.XPath("//*[text()='Don't add members']"));

        public static Element _createProjectButton = new(By.XPath("//*[@class='pfDFL9']//button[2]"));
        public static Element _cancelButton = new(By.XPath("//*[@class='pfDFL9']//button[1]"));

        public NewProjectForm CreateNewProject()
        {
            ClickOnElement(ProjectsPage._createNewProjectButton);
            return this;
        }
        public NewProjectForm FillTheForm(Project project)
        {
            _projectNameField.SendValue(project.ProjectName);
            _projectCodeField.ClearField();
            _projectCodeField.SendValue(project.ProjectCode);
            _descriptionField.SendValue(project.Description);
            return this;
        }
        public NewProjectForm FillRadioButtons(int a, int b)
        {
            if (a == 1)
                ClickOnElement(_privateRadioButton);
            else
                ClickOnElement(_publicRadioButton);

            if (b == 1)
                ClickOnElement(_allMembersRadioButton);
            else if (b == 2)
                ClickOnElement(_groupAccessRadioButton);
            else
                ClickOnElement(_noMembersRadioButton);

            return this;
        }
        public NewProjectForm ClickCreateProjectButton()
        {
            ClickOnElement(_createProjectButton);
            return this;
        }
        public NewProjectForm ClickCancelButton()
        {
            ClickOnElement(_cancelButton);
            return this;
        }

        public static void ClickOnElement(Element element) => element.ClickElement();
    }
}