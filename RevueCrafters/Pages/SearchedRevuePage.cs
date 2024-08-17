using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace RevueCrafters.Pages
{
    public class SearchedRevuePage : BasePage
    {
        public SearchedRevuePage(IWebDriver driver) : base(driver)
        {
        }

        public string Url = BaseUrl + "/Revue/MyRevues";

        public IWebElement FormSearchedRevue => driver.FindElement(By.XPath("//div[@class='row']"));

        public IWebElement SearchedRevue => driver.FindElement(By.XPath("//div[@class='card mb-4 box-shadow']"));
        public IWebElement SearchedRevueTitle => SearchedRevue.FindElement(By.XPath(".//div[@class='text-muted text-center']"));

        public IWebElement SearchedRevueEditButton => SearchedRevue.FindElement(By.XPath(".//a[text()='Edit']"));
        public IWebElement SearchedRevueDeleteButton => SearchedRevue.FindElement(By.XPath(".//a[text()='Delete']"));
        public IWebElement SearchedRevueViewButton => SearchedRevue.FindElement(By.XPath(".//a[text()='View']"));
        public IWebElement SearchedRevueErrorMessage => driver.FindElement(By.CssSelector(".text-muted"));

        public void OpenPage()
        {
            driver.Navigate().GoToUrl(Url);
        }

        public void ScrollToForm()
        {
            Actions actions = new Actions(driver);
            actions.ScrollToElement(FormSearchedRevue).Perform();
        }

        public void SearcheErrorMessage()
        {
            Assert.That(SearchedRevueErrorMessage.Text.Trim(), Is.EqualTo("No Revues yet!"), "Error message was not as expected");
        }
    }
}
