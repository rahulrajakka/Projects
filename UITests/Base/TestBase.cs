using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using NLog;

namespace UITests.Base
{
    public class TestBase
    {
        protected IWebDriver _driver;
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        [SetUp]
        public void SetUp()
        {
            Logger.Info("Starting the browser...");
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("start-maximized");

            try
            {
                _driver = new ChromeDriver(options);
                Logger.Info("Browser launched successfully.");

                // Navigate to the AGDATA website
                _driver.Navigate().GoToUrl("https://www.agdata.com");
                Logger.Info("Navigated to www.agdata.com");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Failed to launch the browser or navigate to the URL.");
                throw;
            }
        }

        [TearDown]
        public void TearDown()
        {
            if (_driver != null)
            {
                Logger.Info("Closing the browser...");
                try
                {
                    _driver.Quit();
                    _driver.Dispose();
                    Logger.Info("Browser closed successfully.");
                }
                catch (Exception ex)
                {
                    Logger.Error(ex, "Failed to close the browser.");
                }
            }
        }
    }
}
