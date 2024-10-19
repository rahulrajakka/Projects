using OpenQA.Selenium;

namespace UITests.Pages
{
    public class HomePageLocators
    {
        // Locator for the "Solutions" menu on the top navigation
        public By SolutionsMenu = By.XPath("//a[text()='Solutions']");

        // Locator for the "Market Intelligence" submenu
        public By MarketIntelligenceOption = By.XPath("//a[text()='Market Intelligence']");

        // Locator for the headings in the "Ways You Benefit" section
        public By BenefitHeadings = By.CssSelector("section h2");

        // Locator for the "Let's Get Started" button
        public By LetsGetStartedButton = By.XPath("//a[@class='btn' and contains(text(), \"Let's Get Started\")]");

        // Locator for the Contact Page title (used to verify that the Contact page is loaded)
        public By ContactPageTitle = By.XPath("//h4[text()='Contact']");
    }
}
