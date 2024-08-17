using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace RevueCrafters.Pages
{
    public class EditRevuePage : BasePage
    {
        public EditRevuePage(IWebDriver driver) : base(driver)
        {
        }

        public string Url = BaseUrl + "/Revue/Edit";

        public IWebElement TitleInput => driver.FindElement(By.XPath("//input[@name='Title']"));
        public IWebElement FormInput => driver.FindElement(By.XPath("//div[@class='row justify-content-center']"));
        public IWebElement PictureInput => driver.FindElement(By.XPath("//input[@name='Url']"));
        public IWebElement DescribeRevueInput => driver.FindElement(By.XPath("//textarea[@name='Description']"));
        public IWebElement EditRevueButton => driver.FindElement(By.XPath("//button[@class='btn btn-primary btn-lg']"));

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
