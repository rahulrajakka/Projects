using NUnit.Framework;
using UITests.Base;
using UITests.Pages;
using NLog; // Adding NLog for logging
using System;
using System.Collections.Generic;

namespace UITests.Tests
{
    [TestFixture]
    public class ContactPageTC : TestBase
    {
        // Create NLog logger
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger(); 
        private HomePageMethods _homePageMethods;

        [SetUp]
        public void Setup()
        {
            Logger.Info("Initializing HomePageMethods for test...");
            _homePageMethods = new HomePageMethods(_driver);
        }

        [Test]
        public void ValidateContactPage()
        {
            try
            {
                // Navigate to Market Intelligence
                Logger.Info("Navigating to Market Intelligence page...");
                _homePageMethods.NavigateToMarketIntelligence();

                // Get and print the headings in the "Ways You Benefit" section
                Logger.Info("Retrieving the headings from 'Ways You Benefit' section...");
                List<string> benefitHeadings = _homePageMethods.GetBenefitHeadings();
                Logger.Debug("Benefit Headings retrieved: {0}", string.Join(", ", benefitHeadings));

                // Click on the "Let's Get Started" button
                Logger.Info("Clicking on 'Let's Get Started' button...");
                _homePageMethods.ClickLetsGetStarted();

                // Validate that the Contact Page is displayed
                Logger.Info("Verifying that the Contact Page is displayed...");
                bool isContactPageDisplayed = _homePageMethods.IsContactPageDisplayed();
                Assert.IsTrue(isContactPageDisplayed, "Contact Page is not displayed");

                Logger.Info("Test Passed: Contact Page is successfully displayed.");
            }
            catch (Exception ex)
            {
                // Log the exception and mark the test as failed
                Logger.Error(ex, "Test Failed with Exception");
                throw;  // Rethrow to ensure the test fails
            }
        }
    }
}
