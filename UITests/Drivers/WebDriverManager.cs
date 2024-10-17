using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace UITests.Drivers
{
    public class WebDriverManager
    {
        public static IWebDriver CreateDriver(string browser)
        {
            if (browser.ToLower() == "chrome")
            {
                return new ChromeDriver();
            }
            // Add logic for other browsers (e.g., Firefox)
            return null;
        }
    }
}
