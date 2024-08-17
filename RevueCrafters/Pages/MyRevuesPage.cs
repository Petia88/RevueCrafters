using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace RevueCrafters.Pages
{
    public class MyRevuesPage : BasePage
    {
        public MyRevuesPage(IWebDriver driver) : base(driver)
        {
        }

        public string Url = BaseUrl + "/Revue/MyRevues";

        public void OpenPage()
        {
            driver.Navigate().GoToUrl(Url);
        }

        public IWebElement FormAllRevues => driver.FindElement(By.XPath("//div[@class='row']"));
        public IWebElement SearchInput => driver.FindElement(By.XPath("//input[@class='form-control']"));
        public IWebElement SearchButton => driver.FindElement(By.XPath("//button[@class='btn btn-outline-primary']"));
        public IReadOnlyCollection<IWebElement> AllRevues => driver.FindElements(By.XPath("//div[@class='card mb-4 box-shadow']"));

        public IWebElement LastCreatedRevueTitle => AllRevues.Last().FindElement(By.XPath(".//div[@class='text-muted text-center']"));
        public IWebElement LastCreatedRevueEditButton => AllRevues.Last().FindElement(By.XPath(".//a[text()='Edit']"));
        public IWebElement LastCreatedRevueDeleteButton => AllRevues.Last().FindElement(By.XPath(".//a[text()='Delete']"));
        public IWebElement LastCreatedRevueViewButton => AllRevues.Last().FindElement(By.XPath(".//a[text()='View']"));

        public void ScrollToAllRevuesForm()
        {
            Actions actions = new Actions(driver);
            actions.ScrollToElement(FormAllRevues).Perform();
        }
    }
}
