using NUnit.Allure.Core;
using ProjectVcode.Constants;
using ProjectVcode.Pages;
using ProjectVcode.Models;

namespace ProjectVcode.Tests
{
    [AllureNUnit]
    internal class InProjectPageTest : BaseTest
    {
        [TestCase("CreatedTestCase1", 4, "TestProject")]
        [Description("Create new case and check its name - positive test")]
        public void CreateCasePositive(string caseName, int caseId, string projectName)
        {
            LoginPage.FastLogin(Consts.UserThreeEmail, Consts.UserThreePass);

            Case testCase = new Case(caseName, caseId);
            ProjectsPage.ChooseProjectByName(projectName);

            InProjectPage.CreateCase(testCase);

            Assert.That(InProjectPage.GetCaseName(caseId), Is.EqualTo(testCase.CaseName));
        }

        [TestCase("CreatedTestCase1", 4, "TestProject")]
        [Description("Delete existing case and check its name doesn't exist - positive test")]
        public void DeleteCasePositive(string caseName, int caseId, string projectName)
        {
            LoginPage.FastLogin(Consts.UserThreeEmail, Consts.UserThreePass);

            Case testCase = new Case(caseName, caseId);
            ProjectsPage.ChooseProjectByName(projectName);

            InProjectPage.DeleteCase(caseId);

            Assert.That(InProjectPage.CheckNoCaseExisting(testCase), Is.False);
        }

        [TestCase("CreatedTestCase99", 4, "TestProject")]
        [Description("Fill the form and cancel, check no case was created - negative test")]
        public void CreateCaseNegative(string caseName, int caseId, string projectName)
        {
            LoginPage.FastLogin(Consts.UserThreeEmail, Consts.UserThreePass);

            Case testCase = new Case(caseName, caseId);
            ProjectsPage.ChooseProjectByName(projectName);

            InProjectPage.ClickCreateCaseButton();
            CreateCasePage.FillTheForm(testCase.CaseName);
            CreateCasePage.CancelTheForm();

            Assert.That(InProjectPage.CheckNoCaseExisting(testCase), Is.False);
        }
    }
}
