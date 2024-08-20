using ProjectVcode.Elements;
using OpenQA.Selenium;
using ProjectVcode.Constants;

namespace ProjectVcode.Pages
{
    internal class ProfileMenu : BasePage
    {
        private static Element _profileIcon = new (By.XPath("//*[@class='CmRKGs']//img"));
        private static Element _profileLink = new(By.XPath("//*[@class='SynGa1']//div//div//ul[2]//li[2]"));

        private static Element _signOutLink = new(By.XPath("//*[@class='SynGa1']//div//div//ul[4]//li[3]"));

        private static Element _firstNameField = new(By.XPath("//*[@id='firstName']"));

        public static void NavigateToProfile()
        {
            ClickOnElement(_profileIcon);
            ClickOnElement(_profileLink);
        }

        public static void SignOut()
        {
            ClickOnElement(_profileIcon);
            ClickOnElement(_signOutLink);
        }

        public static bool CheckProfileName(int nameId)
        {
            if (GetProfileNameElementText() == GetProfileNameConstantText(nameId))
                return true;
            else
                return false;
        }
        public static string GetProfileNameConstantText(int nameId)
        {
            if (nameId == 1)
                return Consts.ProfileFirstName1;
            else if (nameId == 2)
                return Consts.ProfileFirstName2;
            else
                return Consts.ProfileFirstName3;
        }
        public static string GetProfileNameElementText() => _firstNameField.GetElementAttribute("value");

        public static void ClickOnElement(Element element) => element.ClickElement();
    }
}