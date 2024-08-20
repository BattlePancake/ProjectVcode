using ProjectVcode.Factory;
using ProjectVcode.Pages;

namespace ProjectVcode.Tests
{
    internal class BaseTest
    {
        [SetUp]
        public void SetUp()
        {
            BasePage.OpenPage();
        }

        [TearDown]
        public void TearDown()
        {
            Driver.QuitDriver();
        }
    }
}
