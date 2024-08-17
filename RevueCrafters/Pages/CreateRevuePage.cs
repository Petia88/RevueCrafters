using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace RevueCrafters.Pages
{
    public class createRevuePage : BasePage
    {
        public createRevuePage(IWebDriver driver) : base(driver)
        {
        }

        public string Url = BaseUrl + "/Revue/Create#createRevue";

        public IWebElement TitleInput => driver.FindElement(By.XPath("//input[@name='Title']"));
        public IWebElement FormInput => driver.FindElement(By.XPath("//div[@class='row justify-content-center']"));
        public IWebElement PictureInput => driver.FindElement(By.XPath("//input[@name='Url']"));
        public IWebElement DescribeRevueInput => driver.FindElement(By.XPath("//textarea[@name='Description']"));
        public IWebElement CreateRevueButton => driver.FindElement(By.XPath("//button[@class='btn btn-primary btn-lg']"));

        public IWebElement MainErrorMessage => driver.FindElement(By.XPath("//div[@class='text-danger validation-summary-errors']//li"));
        public IWebElement TitleErrorMessage => driver.FindElements(By.XPath("//span[@class='text-danger field-validation-error']"))[0];
        public IWebElement DescriptionErrorMessage => driver.FindElements(By.XPath("//span[@class='text-danger field-validation-error']"))[1];

        public void AssertEmptyMainErrorMessage()
        {
            Assert.That(MainErrorMessage.Text.Trim(), Is.EqualTo("Unable to create new Revue!"), "Error message was not as expected");
        }

        public void AssertEmptyTitleMessage()
        {
            Assert.That(TitleErrorMessage.Text.Trim(), Is.EqualTo("The Title field is required."), "Error message was not as expected");
        }

        public void AssertEmptyDescriptionMessage()
        {
            Assert.That(DescriptionErrorMessage.Text.Trim(), Is.EqualTo("The Description field is required."), "Error message was not as expected");
        }

        public void OpenPage()
        {
            driver.Navigate().GoToUrl(Url);
        }

        public void ScrollToForm()
        {
            Actions actions = new Actions(driver);
            actions.ScrollToElement(FormInput).Perform();
        }
    }
}
