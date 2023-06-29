using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanitAssignment.PageObjects
{
    public class ShopPage
    {
        IWebDriver driver;

        public ShopPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        #region Web Elements

        By StuffedFrogBuyButton = By.XPath("//h4[contains(text(), 'Stuffed Frog')]/following-sibling::p/a");

        By FluffyBunnyBuyButton = By.XPath("//h4[contains(text(), 'Fluffy Bunny')]/following-sibling::p/a");

        By ValentineBearBuyButton = By.XPath("//h4[contains(text(), 'Valentine Bear')]/following-sibling::p/a");

        By StuffedFrogPrice = By.XPath("//h4[contains(text(), 'Stuffed Frog')]/following-sibling::p/span");

        By FluffyBunnyPrice = By.XPath("//h4[contains(text(), 'Fluffy Bunny')]/following-sibling::p/span");

        By ValentineBearPrice = By.XPath("//h4[contains(text(), 'Valentine Bear')]/following-sibling::p/span");

        #endregion

        #region Methods

        public void Buy2StuffedFrog()
        {
            for (int i = 0; i < 2; i++)
            {
                driver.FindElement(StuffedFrogBuyButton).Click();
            }
        }

        public void Buy5FluffyBunny()
        {
            for(int i = 0; i < 5; i++)
            {
                driver.FindElement(FluffyBunnyBuyButton).Click();
            }
        }

        public void Buy3ValentineBear()
        {
            for (int i = 0; i < 3; i++)
            {
                driver.FindElement(ValentineBearBuyButton).Click();
            }
        }

        public string GetExpectedStuffedFrogPrice()
        {
            return driver.FindElement(StuffedFrogPrice).Text;
        }

        public string GetExpectedFluffyBunnyPrice()
        {
            return driver.FindElement(FluffyBunnyPrice).Text;
        }

        public string GetExpectedValentineBearPrice()
        {
            return driver.FindElement(ValentineBearPrice).Text;
        }

        #endregion
    }

}
