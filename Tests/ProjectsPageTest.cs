using NUnit.Allure.Core;
using ProjectVcode.Constants;
using ProjectVcode.Models;
using ProjectVcode.Pages;

namespace ProjectVcode.Tests
{
    [AllureNUnit]
    internal class ProjectsPageTest : BaseTest
    {
        [TestCase("NewTestProjectOne", "NTPO", "")]
        [Description("User1 - Create new project and check created project name - positive test")]
        public void CreateProjectUser1Positive(string name, string code, string description)
        {
            LoginPage.FastLogin(Consts.UserOneEmail, Consts.UserOnePass);

            NewProjectForm newProjectForm = new();
            Project project = new Project(name, code, description);

            newProjectForm.CreateNewProject()
                          .FillRadioButtons(1, 1)
                          .FillTheForm(project)
                          .ClickCreateProjectButton();

            Assert.That(InProjectPage.CheckProjectNames(project), Is.True);
        }

        [TestCase("NewTestProjectTwo", "NTPW", "")]
        [Description("User2 - Create new project and check created project name - positive test")]
        public void CreateProjectUser2Positive(string name, string code, string description)
        {
            LoginPage.FastLogin(Consts.UserTwoEmail, Consts.UserTwoPass);

            NewProjectForm newProjectForm = new();
            Project project = new Project(name, code, description);

            newProjectForm.CreateNewProject()
                          .FillRadioButtons(1, 1)
                          .FillTheForm(project)
                          .ClickCreateProjectButton();

            Assert.That(InProjectPage.CheckProjectNames(project), Is.True);
        }

        [TestCase("NewTestProjectThree", "NTPT", "CreatedDescription")]
        [Description("User3 - Create new project and check created project name - positive test")]
        public void CreateProjectUser3Positive(string name, string code, string description)
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

        [TestCase("NewTestProjectThree", 3)]
        [Description("Delete existing project and check that no name existing - positive test")]
        public void DeleteProjectPositive(string name, int id)
        {
            LoginPage.FastLogin(Consts.UserThreeEmail, Consts.UserThreePass);

            Project project = new Project(name, id);
            ProjectsPage.DeleteProject(project.ProjectId);

            Assert.That(ProjectsPage.CheckProjectExists(project), Is.False);
        }

        [TestCase("TestProject10", "TP10", "CreatedTestDescription")]
        [Description("Fill the form and cancel, check no project was created - negative test")]
        public void CreateProjectNegative(string name, string code, string description)
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
