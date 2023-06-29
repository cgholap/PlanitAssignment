using OpenQA.Selenium;

namespace PlanitAssignment.PageObjects
{
    public class ContactPage
    {
        IWebDriver driver;

        public ContactPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        #region Web Elements

        By Forename = By.Id("forename");

        By Email = By.Id("email");

        By Message = By.Id("message");

        By SubmitButton = By.XPath("//a[@class='btn-contact btn btn-primary']");

        By AlertError = By.XPath("//div[@class='alert alert-error ng-scope']");

        By ForenameError = By.Id("forename-err");

        By EmailError = By.Id("email-err");

        By MessageError = By.Id("message-err");

        By SuccessMessage = By.XPath("//div[@class='alert alert-success']");

        #endregion

        #region Methods

        public void EnterForename(string forename)
        {
            driver.FindElement(Forename).SendKeys(forename);
        }

        public void EnterEmail(string email)
        {
            driver.FindElement(Email).SendKeys(email);
        }

        public void EnterMessage(string message)
        {
            driver.FindElement(Message).SendKeys(message);
        }

        public void ClickSubmitButton()
        {
            driver.FindElement(SubmitButton).Click();
        }

        public string GetAlertErrorText()
        {
            return driver.FindElement(AlertError).Text;
        }

        public string GetForenameErrorText()
        {
            return driver.FindElement(ForenameError).Text;
        }

        public string GetEmailErrorText()
        {
            return driver.FindElement(EmailError).Text;
        }

        public string GetMessageErrorText()
        {
            return driver.FindElement(MessageError).Text;
        }

        public string GetSuccessMessageText()
        {
            return driver.FindElement(SuccessMessage).Text;
        }

        public void WaitForFormSubmit()
        {
            Thread.Sleep(10000);
        }

        #endregion
    }
}
