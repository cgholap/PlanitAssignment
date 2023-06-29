using OpenQA.Selenium;
using PlanitAssignment.PageObjects;

namespace PlanitAssignment.Tests
{
    public class TestCase3
    {
        IWebDriver driver;
        BrowserManager browserManager;
        Menu menu;
        ShopPage shopPage;
        CartPage cartPage;

        [Test]
        public void ValidaeBuyProducts()
        {
            // Launch application.
            browserManager = new BrowserManager();
            driver = browserManager.OpenHomePage();

            // Go to Shop page.
            menu = new Menu(driver);
            menu.GoToShopPage();

            // Buy 2 Stuffed Frog, 5 Fluffy Bunny, 3 Valentine Bear.
            shopPage = new ShopPage(driver);
            shopPage.Buy2StuffedFrog();
            shopPage.Buy5FluffyBunny();
            shopPage.Buy3ValentineBear();

            var ExpectedStuffedFrogPrice = shopPage.GetExpectedStuffedFrogPrice();
            var GetExpectedFluffyBunnyPrice = shopPage.GetExpectedFluffyBunnyPrice();
            var GetExpectedValentineBearPrice = shopPage.GetExpectedValentineBearPrice();

            // Go to the cart page.
            menu = new Menu(driver);
            menu.GoToCartPage();
            cartPage = new CartPage(driver);

            // Verify the subtotal for each product is correct.
            Assert.That(cartPage.GetActualStuffedFrogSubtotal(), Is.EqualTo(cartPage.GetExpectedStuffedFrogSubtotal()));
            Assert.That(cartPage.GetActualFluffyBunnySubtotal(), Is.EqualTo(cartPage.GetExpectedFluffyBunnySubtotal()));
            Assert.That(cartPage.GetActualValentineBearSubtotal(), Is.EqualTo(cartPage.GetExpectedValentineBearSubtotal()));

            // Verify the price for each product.
            Assert.That(cartPage.GetActualStuffedFrogPrice(), Is.EqualTo(ExpectedStuffedFrogPrice));
            Assert.That(cartPage.GetActualFluffyBunnyPrice(), Is.EqualTo(GetExpectedFluffyBunnyPrice));
            Assert.That(cartPage.GetActualValentineBearPrice(), Is.EqualTo(GetExpectedValentineBearPrice));

            // Verify that total = sum(sub totals).
            Assert.That(cartPage.GetActualTotal(), Is.EqualTo(cartPage.GetExpectedTotal()));

            // Close browser.
            browserManager.CloseApplication();
        }
    }
}
