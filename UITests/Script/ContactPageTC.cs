using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using UITests.Pages;

namespace UITests.Tests
{
    [TestFixture]
    public class ContactPageTest
    {
        private IWebDriver _driver;
        private HomePageMethods _homePageMethods;

        [SetUp]
        public void SetUp()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("start-maximized");
            _driver = new ChromeDriver(options);

            // Initialize HomePageMethods to interact with the homepage
            _homePageMethods = new HomePageMethods(_driver);
        }

        [Test]
        public void VerifyNavigationToContactPage()
        {
            // Navigate to AGDATA homepage
            _driver.Navigate().GoToUrl("https://www.agdata.com");

            // Hover over "Solutions" menu and click "Market Intelligence"
            _homePageMethods.HoverOverSolutionsMenu();
            _homePageMethods.ClickMarketIntelligence();

            // Scroll to "Let's Get Started" and click it
            _homePageMethods.ScrollToLetsGetStarted();
            _homePageMethods.ClickLetsGetStarted();

            // Assert that the "Contact" page is loaded
            Assert.IsTrue(_homePageMethods.IsContactPageLoaded(), "The Contact page did not load.");
        }

        [TearDown]
        public void TearDown()
        {
            // Properly dispose of the WebDriver to release resources and close the browser
            if (_driver != null)
            {
                _driver.Quit();   // Close the browser
                _driver.Dispose();  // Dispose of WebDriver resources
            }
        }
    }
}
