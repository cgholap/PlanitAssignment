using OpenQA.Selenium;

namespace PlanitAssignment.PageObjects
{
    public class CartPage
    {
        IWebDriver driver;

        public CartPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        #region Web Elements

        By StuffedFrogPrice = By.XPath("//img[@src='images/src-embed/frog.jpg']/../following-sibling::td[contains(text(), '$10.99')]");

        By FluffyBunnyPrice = By.XPath("//img[@src='images/src-embed/bunny.jpg']/../following-sibling::td[contains(text(), '$9.99')]");

        By ValentineBearPrice = By.XPath("//img[@src='images/src-embed/valentine.jpg']/../following-sibling::td[contains(text(), '$14.99')]");

        By StuffedFrogSubtotal = By.XPath("//img[@src='images/src-embed/frog.jpg']/../following-sibling::td[contains(text(), '$21.98')]");

        By FluffyBunnySubtotal = By.XPath("//img[@src='images/src-embed/bunny.jpg']/../following-sibling::td[contains(text(), '$49.95')]");

        By ValentineBearSubtotal = By.XPath("//img[@src='images/src-embed/valentine.jpg']/../following-sibling::td[contains(text(), '$44.97')]");

        By TotalPrice = By.XPath("//strong[@class='total ng-binding']");

        #endregion

        #region Methods

        public string GetActualStuffedFrogPrice()
        {
            return driver.FindElement(StuffedFrogPrice).Text;
        }

        public string GetActualFluffyBunnyPrice()
        {
            return driver.FindElement(FluffyBunnyPrice).Text;
        }

        public string GetActualValentineBearPrice()
        {
            return driver.FindElement(ValentineBearPrice).Text;
        }
        public double GetActualStuffedFrogSubtotal()
        {
            string StuffedFrogPrice = GetActualStuffedFrogPrice().Replace("$", "").Trim();
            double StuffedFrogSubtotal = Convert.ToDouble(StuffedFrogPrice) * 2;
            return StuffedFrogSubtotal;
        }

        public double GetExpectedStuffedFrogSubtotal()
        {
            return Convert.ToDouble(driver.FindElement(StuffedFrogSubtotal).Text.Replace("$", "").Trim());
        }

        public double GetActualFluffyBunnySubtotal()
        {
            string FluffyBunnyPrice = GetActualFluffyBunnyPrice().Replace("$", "").Trim();
            double FluffyBunnySubtotal = Convert.ToDouble(FluffyBunnyPrice) * 5;
            return FluffyBunnySubtotal;
        }

        public double GetExpectedFluffyBunnySubtotal()
        {
            return Convert.ToDouble(driver.FindElement(FluffyBunnySubtotal).Text.Replace("$", "").Trim());
        }

        public double GetActualValentineBearSubtotal()
        {
            string ValentineBearPrice = GetActualValentineBearPrice().Replace("$", "").Trim();
            double ValentineBearSubtotal = Convert.ToDouble(ValentineBearPrice) * 3;
            return ValentineBearSubtotal;
        }

        public double GetExpectedValentineBearSubtotal()
        {
            return Convert.ToDouble(driver.FindElement(ValentineBearSubtotal).Text.Replace("$", "").Trim());
        }

        public double GetActualTotal()
        {
            double Total = GetExpectedStuffedFrogSubtotal() + GetExpectedFluffyBunnySubtotal() + GetExpectedValentineBearSubtotal();
            return Total;
        }

        public double GetExpectedTotal()
        {
            string Total = driver.FindElement(TotalPrice).Text.Replace("Total:", "").Trim();
            return Convert.ToDouble(Total);
        }

        #endregion
    }
}
