using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using NLog; // Adding NLog for logging

namespace UITests.Pages
{
    public class HomePageMethods
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();  // NLog logger instance
        private IWebDriver _driver;
        private WebDriverWait _wait;
        private HomePageLocators _locators;

        public HomePageMethods(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(15));  // Wait for elements to load
            _locators = new HomePageLocators();
        }

        // Hover over "Solutions" and click on "Market Intelligence"
        public void NavigateToMarketIntelligence()
        {
            Logger.Info("Hovering over 'Solutions' menu...");
            Actions actions = new Actions(_driver);

            var solutionsMenu = _wait.Until(ExpectedConditions.ElementIsVisible(_locators.SolutionsMenu));
            actions.MoveToElement(solutionsMenu).Perform();

            Logger.Info("Clicking on 'Market Intelligence' submenu...");
            var marketIntelligenceOption = _wait.Until(ExpectedConditions.ElementToBeClickable(_locators.MarketIntelligenceOption));
            marketIntelligenceOption.Click();
        }

        // Retrieve headings in the "Ways You Benefit" section
        public List<string> GetBenefitHeadings()
        {
            Logger.Info("Getting headings from the 'Ways You Benefit' section...");
            List<string> headingsText = new List<string>();

            var headings = _driver.FindElements(_locators.BenefitHeadings);
            foreach (var heading in headings)
            {
                headingsText.Add(heading.Text);
            }

            Logger.Debug($"Retrieved {headingsText.Count} headings.");
            return headingsText;
        }

        // Scroll to and click on the "Let's Get Started" button
        public void ClickLetsGetStarted()
        {
            Logger.Info("Scrolling to and clicking 'Let’s Get Started' button...");
            var letsGetStartedButton = _wait.Until(ExpectedConditions.ElementToBeClickable(_locators.LetsGetStartedButton));
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView(true);", letsGetStartedButton);
            letsGetStartedButton.Click();
        }

        // Validate that the Contact Page is displayed by checking the page title
        public bool IsContactPageDisplayed()
        {
            Logger.Info("Checking if Contact Page is displayed...");
            bool isDisplayed = _wait.Until(ExpectedConditions.ElementIsVisible(_locators.ContactPageTitle)).Displayed;
            Logger.Info(isDisplayed ? "Contact Page is displayed." : "Contact Page is not displayed.");
            return isDisplayed;
        }
    }
}
