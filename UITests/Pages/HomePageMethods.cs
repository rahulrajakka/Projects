using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace UITests.Pages
{
    public class HomePageActions
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;

        // Constructor to initialize WebDriver and WebDriverWait
        public HomePageActions(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));
        }

        // Hover over the "Solutions" menu
        public void HoverOverSolutionsMenu()
        {
            Actions actions = new Actions(_driver);
            IWebElement solutionsElement = _driver.FindElement(HomePageLocators.solutionsMenu);
            actions.MoveToElement(solutionsElement).Perform();
        }

        // Click on "Market Intelligence"
        public void ClickMarketIntelligence()
        {
            IWebElement marketIntelligenceElement = _wait.Until(ExpectedConditions.ElementToBeClickable(HomePageLocators.marketIntelligenceOption));
            marketIntelligenceElement.Click();
        }

        // Scroll to "Let's Get Started" button
        public void ScrollToLetsGetStarted()
        {
            IWebElement letsGetStartedElement = _wait.Until(ExpectedConditions.ElementToBeClickable(HomePageLocators.letsGetStartedButton));
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView(true);", letsGetStartedElement);
        }

        // Click "Let's Get Started"
        public void ClickLetsGetStarted()
        {
            IWebElement letsGetStartedElement = _wait.Until(ExpectedConditions.ElementToBeClickable(HomePageLocators.letsGetStartedButton));
            letsGetStartedElement.Click();
        }

        // Validate if we are on the "Contact" page
        public bool IsContactPageLoaded()
        {
            return _driver.Url.Contains("contact");
        }
    }
}
