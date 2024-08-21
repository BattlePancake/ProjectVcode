using NUnit.Allure.Core;
using ProjectVcode.Constants;
using ProjectVcode.Pages;
using ProjectVcode.Models;

namespace ProjectVcode.Tests
{
    [AllureNUnit]
    internal class InProjectPageTest : BaseTest
    {
        [TestCase("Test Case Name 3", 4, "TestProject")]
        [Description("Create new case and check its name - positive test")]
        public void InProjectPageTest1(string caseName, int caseId, string projectName)
        {
            LoginPage.FastLogin(Consts.UserThreeEmail, Consts.UserThreePass);

            Case testCase = new Case(caseName, caseId);
            ProjectsPage.ChooseProjectByName(projectName);

            InProjectPage.CreateCase(testCase);

            Assert.That(InProjectPage.GetCaseName(caseId), Is.EqualTo(testCase.CaseName));
        }

        [TestCase("Test Case Name 3", 5, "TestProject")]
        [Description("Delete existing case and check its name doesn't exist - positive test")]
        public void InProjectPageTest2(string caseName, int caseId, string projectName)
        {
            LoginPage.FastLogin(Consts.UserThreeEmail, Consts.UserThreePass);

            Case testCase = new Case(caseName, caseId);
            ProjectsPage.ChooseProjectByName(projectName);

            InProjectPage.DeleteCase(caseId);

            Assert.That(InProjectPage.CheckNoCaseExisting(testCase), Is.False);
        }

        [TestCase("Test Case Name 4", 5, "TestProject")]
        [Description("Fill the form and cancel, check no project was created - negative test")]
        public void InProjectPageTest3(string caseName, int caseId, string projectName)
        {
            LoginPage.FastLogin(Consts.UserThreeEmail, Consts.UserThreePass);

            Case testCase = new Case(caseName, caseId);
            ProjectsPage.ChooseProjectByName(projectName);

            InProjectPage.ClickCreateCaseButton();
            CreateCasePage.FillTheForm(testCase.CaseName);
            CreateCasePage.CancelTheForm();

            Assert.That(InProjectPage.CheckNoCaseExisting(testCase), Is.False);
        }

        [TestCase("Test Suite Name 1", "TestProject")]
        [Description("Create new suite and check its name - positive test")]
        public void InProjectPageTest4(string suiteName, string projectName)
        {
            LoginPage.FastLogin(Consts.UserThreeEmail, Consts.UserThreePass);

            Suite testSuite = new Suite(suiteName);
            ProjectsPage.ChooseProjectByName(projectName);

            InProjectPage.CreateSuite(testSuite);

            //Assert.That(InProjectPage.GetCaseName(caseId), Is.EqualTo(testCase.CaseName));
        }
    }
}
