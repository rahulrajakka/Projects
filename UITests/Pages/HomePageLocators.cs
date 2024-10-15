using OpenQA.Selenium;

namespace UITests.Pages
{
    public class HomePageLocators
    {
        // Locators
        public static By solutionsMenu = By.XPath("//a[text()='Solutions']");
        public static By marketIntelligenceOption = By.XPath("//a[text()='Market Intelligence']");
        public static By letsGetStartedButton = By.XPath("//a[@class='btn' and contains(text(), \"Let's Get Started\")]");
    }
}