using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using PlanitAssignment.PageObjects;
using System.Linq;

namespace PlanitAssignment.Tests
{
    public class TestCase1
    {
        IWebDriver driver;
        BrowserManager browserManager;
        Menu menu;
        ContactPage contactPage;

        [Test]
        public void ValidateErrorMessage()
        {
            // Launch application.
            browserManager = new BrowserManager();
            driver = browserManager.OpenHomePage();

            // Go to Contact page.
            menu = new Menu(driver);
            menu.GoToContactPage();

            // Click submit button.
            contactPage = new ContactPage(driver);
            contactPage.ClickSubmitButton();

            // Verify error messages.
            Assert.That(contactPage.GetAlertErrorText(), Is.EqualTo("We welcome your feedback - but we won't get it unless you complete the form correctly."));
            Assert.That(contactPage.GetForenameErrorText(), Is.EqualTo("Forename is required"));
            Assert.That(contactPage.GetEmailErrorText(), Is.EqualTo("Email is required"));
            Assert.That(contactPage.GetMessageErrorText(), Is.EqualTo("Message is required"));

            // Populate mandatory fields.
            contactPage.EnterForename("Chaitanya");
            contactPage.EnterEmail("test@gmail.com");
            contactPage.EnterMessage("This is test form.");
            contactPage.ClickSubmitButton();
            contactPage.WaitForFormSubmit();

            // Validate errors are gone.
            Assert.False(driver.PageSource.Contains("We welcome your feedback - but we won't get it unless you complete the form correctly."));
            Assert.False(driver.PageSource.Contains("Forename is required"));
            Assert.False(driver.PageSource.Contains("Email is required"));
            Assert.False(driver.PageSource.Contains("Message is required"));

            // Close browser.
            browserManager.CloseApplication();

        }
    }
}