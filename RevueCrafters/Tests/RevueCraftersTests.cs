using RevueCrafters.Pages;

namespace RevueCrafters.Tests
{
    public class RevueCraftersTests : BaseTest
    {
        private string lastRevueTitle;
        private string lastRevueDescription;

        [Test, Order(1)]
        public void CreateRevuewithInvalidDataTest()
        {
            createRevuePage.OpenPage();

            createRevuePage.ScrollToForm();
            createRevuePage.CreateRevueButton.Click();

            Assert.That(driver.Url, Is.EqualTo(createRevuePage.Url), "The Url is not as expected");
            createRevuePage.AssertEmptyMainErrorMessage();

        }

        [Test, Order(2)]
        public void CreateRevuewitValidDataTest()
        {
            lastRevueTitle = GenerateRandomTitle();
            lastRevueDescription = GenerateRandomDescription();

            createRevuePage.OpenPage();

            createRevuePage.ScrollToForm();

            createRevuePage.TitleInput.Clear();
            createRevuePage.TitleInput.SendKeys(lastRevueTitle);
            createRevuePage.DescribeRevueInput.Clear();
            createRevuePage.DescribeRevueInput.SendKeys(lastRevueDescription);

            createRevuePage.CreateRevueButton.Click();

            myRevuesPage.ScrollToAllRevuesForm();

            Assert.That(myRevuesPage.LastCreatedRevueTitle.Text.Trim(), Is.EqualTo(lastRevueTitle), "The revue was not created");

        }

        [Test, Order(3)]
        public void SearchforRevueTitleTest()
        {
            myRevuesPage.OpenPage();
            myRevuesPage.ScrollToAllRevuesForm();

            myRevuesPage.SearchInput.Clear();
            myRevuesPage.SearchInput.SendKeys(lastRevueTitle);
            myRevuesPage.SearchButton.Click();

            Assert.That(searchedRevuePage.SearchedRevueTitle.Text.Trim(), Is.EqualTo(lastRevueTitle), "The revue was not found");
        }

        [Test, Order(4)]
        public void EditLastCreatedRevueTitleTest()
        {
            lastRevueTitle = lastRevueTitle + "Edited";
            myRevuesPage.OpenPage();
            myRevuesPage.ScrollToAllRevuesForm();

            myRevuesPage.LastCreatedRevueEditButton.Click();
            
            editRevuePage.ScrollToForm();
            editRevuePage.TitleInput.Clear();
            editRevuePage.TitleInput.SendKeys(lastRevueTitle);
            editRevuePage.EditRevueButton.Click();

            Assert.That(driver.Url, Is.EqualTo(myRevuesPage.Url), "The Url is not as expected");

            myRevuesPage.ScrollToAllRevuesForm();
            Assert.That(myRevuesPage.LastCreatedRevueTitle.Text.Trim(), Is.EqualTo(lastRevueTitle), "The review was not edited");
        }

        [Test, Order(5)]
        public void DeleteLastCreatedRevueTitleTest()
        {
            myRevuesPage.OpenPage();
            myRevuesPage.ScrollToAllRevuesForm();

            myRevuesPage.LastCreatedRevueDeleteButton.Click();

            Assert.That(driver.Url, Is.EqualTo(myRevuesPage.Url), "The Url is not as expected");
            myRevuesPage.ScrollToAllRevuesForm();

            Assert.That(myRevuesPage.LastCreatedRevueTitle.Text.Trim(), Is.Not.EqualTo(lastRevueTitle), "The review was not edited");
        }

        [Test, Order(6)]
        public void SearchforNonExistentRevueTest()
        {
            myRevuesPage.OpenPage();
            myRevuesPage.ScrollToAllRevuesForm();

            myRevuesPage.SearchInput.Clear();
            myRevuesPage.SearchInput.SendKeys("Unreal title");
            myRevuesPage.SearchButton.Click();

            searchedRevuePage.SearcheErrorMessage();
        }
    }
}