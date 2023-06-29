using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace PlanitAssignment
{
    public class BrowserManager
    {
        public IWebDriver driver { get; set; }

        public IWebDriver OpenHomePage()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Window.Maximize();
            driver.Url = "http://jupiter.cloud.planittesting.com";
            return driver;
        }

        public void CloseApplication()
        {
            driver.Close();
        }
    }
}
