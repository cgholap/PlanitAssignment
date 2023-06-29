using OpenQA.Selenium;
using PlanitAssignment.PageObjects;


namespace PlanitAssignment.Tests
{
    public class TestCase2
    {
        IWebDriver driver;
        BrowserManager browserManager;
        Menu menu;
        ContactPage contactPage;

        [Test]
        [Repeat(5)]
        public void ValidateSuccessMessage()
        {
            // Launch application.
            browserManager = new BrowserManager();
            driver = browserManager.OpenHomePage();

            // Go to Contact page.
            menu = new Menu(driver);
            menu.GoToContactPage();

            // Populate mandatory fields.
            contactPage = new ContactPage(driver);
            contactPage.EnterForename("Chaitanya");
            contactPage.EnterEmail("test@gmail.com");
            contactPage.EnterMessage("This is test form.");

            // Click submit button.
            contactPage.ClickSubmitButton();
            contactPage.WaitForFormSubmit();

            // Validate successful submission message.
            Assert.That(contactPage.GetSuccessMessageText(), Is.EqualTo("Thanks Chaitanya, we appreciate your feedback."));

            // Close browser.
            browserManager.CloseApplication();
        }
    }
}
