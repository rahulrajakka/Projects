using NUnit.Framework;
using UITests.Base;
using UITests.Pages;

namespace UITests.Tests
{
    [TestFixture]
    public class ContactPageTest : TestBase
    {
        private HomePageMethods _homePageMethods;

        [SetUp]
        public void Init()
        {
            _homePageMethods = new HomePageMethods(_driver);
        }

        [Test]
        public void VerifyNavigationToContactPage()
        {
            _driver.Navigate().GoToUrl("https://www.agdata.com");
            _homePageMethods.HoverOverSolutionsMenu();
            _homePageMethods.ClickMarketIntelligence();
            _homePageMethods.ScrollToLetsGetStarted();
            _homePageMethods.ClickLetsGetStarted();
            Assert.IsTrue(_homePageMethods.IsContactPageLoaded());
        }
    }
}
