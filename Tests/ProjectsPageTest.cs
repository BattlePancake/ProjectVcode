using NUnit.Allure.Core;
using ProjectVcode.Constants;
using ProjectVcode.Models;
using ProjectVcode.Pages;

namespace ProjectVcode.Tests
{
    [AllureNUnit]
    internal class ProjectsPageTest : BaseTest
    {
        //[TestCase("TestProject1", "TP1", "TestDescription1")]

        //[TestCase("TestProject2", "TP2", "TestDescription2")]

        [TestCase("TestProject3", "TP3", "TestDescription3")]
        [Description("Create new project and check created project name - positive test")]
        public void ProjectPageTest1(string name, string code, string description)
        {
            LoginPage.FastLogin(Consts.UserThreeEmail, Consts.UserThreePass);

            NewProjectForm newProjectForm = new();
            Project project = new Project(name, code, description);

            newProjectForm.CreateNewProject()
                          .FillRadioButtons(1, 1)
                          .FillTheForm(project)
                          .ClickCreateProjectButton();  

            Assert.That(InProjectPage.CheckProjectNames(project), Is.True);
        }

        [TestCase("TestProject3", 3)]
        [Description("Delete existing project and check that no name existing - positive test")]
        public void ProjectPageTest2(string name, int id)
        {
            LoginPage.FastLogin(Consts.UserThreeEmail, Consts.UserThreePass);

            Project project = new Project(name, id);
            ProjectsPage.DeleteProject(project.ProjectId);

            Assert.That(ProjectsPage.CheckProjectExists(project), Is.False);
        }

        [TestCase("TestProject10", "TP10", "")]
        [Description("Fill the form and cancel, check no project was created - negative test")]
        public void ProjectPageTest3(string name, string code, string description)
        {
            LoginPage.FastLogin(Consts.UserThreeEmail, Consts.UserThreePass);

            NewProjectForm newProjectForm = new();
            Project project = new Project(name, code, description);

            newProjectForm.CreateNewProject()
                          .FillTheForm(project)
                          .ClickCancelButton();

            Assert.That(ProjectsPage.CheckProjectExists(project), Is.False);
        }
    }
}
