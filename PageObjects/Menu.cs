using OpenQA.Selenium;

namespace PlanitAssignment.PageObjects
{
    public class Menu
    {
        IWebDriver driver;

        public Menu(IWebDriver driver)
        {
            this.driver = driver;
        }

        By HomePage = By.XPath("//a[@href='#/home']");

        By ShopPage = By.XPath("//a[@href='#/shop']");

        By ContactPage = By.XPath("//a[@href='#/contact']");

        By CartPage = By.XPath("//a[@href='#/cart']");

        public void GoToHomePage()
        {
            driver.FindElement(HomePage).Click();
            Thread.Sleep(2000);
        }
        public void GoToShopPage()
        {
            driver.FindElement(ShopPage).Click();
            Thread.Sleep(2000);
        }
        public void GoToContactPage()
        {
            driver.FindElement(ContactPage).Click();
            Thread.Sleep(2000);
        }

        public void GoToCartPage()
        {
            driver.FindElement(CartPage).Click();
            Thread.Sleep(2000);
        }
    }
}
