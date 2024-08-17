using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using RevueCrafters.Pages;
using OpenQA.Selenium.Interactions;

namespace RevueCrafters.Tests
{
    public class BaseTest
    {
        public IWebDriver driver;
        public LoginPage loginPage;
        public createRevuePage createRevuePage;
        public MyRevuesPage myRevuesPage;
        public SearchedRevuePage searchedRevuePage;
        public EditRevuePage editRevuePage;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddUserProfilePreference("profile.password_manager_enable", false);
            chromeOptions.AddArgument("--disable-search-engine-choice-screen");

            driver = new ChromeDriver(chromeOptions);
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            loginPage = new LoginPage(driver);
            createRevuePage = new createRevuePage(driver);
            myRevuesPage = new MyRevuesPage(driver);
            searchedRevuePage = new SearchedRevuePage(driver);
            editRevuePage = new EditRevuePage(driver);

            loginPage.OpenPage();
            Actions actions = new Actions(driver);
            var sectionLogin = driver.FindElement(By.XPath("//section[@class='mb-5']"));
            actions.ScrollToElement(sectionLogin).Perform();
            loginPage.PerformLogin("petqtest@test.bg", "123456");
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            driver.Quit();
            driver.Dispose();
        }

        public string GenerateRandomTitle()
        {
            var random = new Random();
            return "TITLE: " + random.Next(1000, 10000);
        }

        public string GenerateRandomDescription()
        {
            var random = new Random();
            return "DESCRIPTION: " + random.Next(1000, 10000);
        }
    }
}
