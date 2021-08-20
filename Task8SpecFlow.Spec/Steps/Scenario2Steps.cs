using NUnit.Framework;
using OpenQA.Selenium;
using System;
using Task8SpecFlow.Spec.POM;
using TechTalk.SpecFlow;

namespace Task8SpecFlow.Spec.Steps
{
    [Binding]
    public class Scenario2Steps
    {

        private IWebDriver _driver;
        public Scenario2Steps(IWebDriver driver)
        {
            _driver = driver;
        }

        [Given(@"the search query (.*) is displayed in the resualt page")]
        public void GivenTheSearchQueryIsDisplayedInTheResualtPage(string namePage)
        {           
            Assert.IsTrue(new CatalogPageObject(_driver).CheckSearchText(namePage), "Searching is not correct!");
        }

        [When(@"move and click ""(.*)"" button")]
        public void WhenMoveAndClickButton(string buttonName)
        {
            new CatalogPageObject(_driver).MoveThenClickButton(buttonName);
        }
        
        
        [Then(@"modal window with a title ""(.*)"" is displayed")]
        public void ThenModalWindowWithATitleIsDisplayed(string title)
        {
            Assert.IsTrue(new ItemPageObject(_driver).CheckModuleTitle(title), "Title in module windows is incorrect!");
        }

        [When(@"choose conditions for Quantity = '(.*)', Size = '(.*)', Color = '(.*)'")]
        public void WhenChooseConditionsForQuantitySizeColor(string qty, string size, string color)
        {
            TestSettings.InfoProducts = TestSettings.InfoProducts + new ItemPageObject(_driver).GetItemName()+ " Color : " + color.Trim() + ", Size : " + size.Trim() + qty + new ItemPageObject(_driver).GetItemPrice() + decimal.Parse(qty.Trim())* new ItemPageObject(_driver).GetItemPrice();

            new ItemPageObject(_driver).ChooseQnt(qty);
            new ItemPageObject(_driver).ChooseSize(size);
            new ItemPageObject(_driver).ChooseColor(color);
        }
        
        [When(@"delete item '(.*)' from cart")]
        public void WhenDeleteItemFromCart(string productName)
        {
            new CartPageObject(_driver).DeleteItemFromCart(productName);
        }

        [Then(@"click ""(.*)"" button")]
        public void ThenClickButton(string buttonName)
        {
            new ItemPageObject(_driver).ClickButtonInModuleWindow(buttonName);
        }

        [When(@"click ""(.*)"" button")]
        public void WhenClickButton(string buttonName)
        {
            new ItemPageObject(_driver).ClickButtonItemPage(buttonName);
        }

     
        [Then(@"only item '(.*)' is displayed in cart")]
        public void ThenOnlyItemIsDisplayedInCart(string productName)
        {
            Assert.IsTrue(new CartPageObject(_driver).IsExist(productName));
            Assert.AreEqual(new CartPageObject(_driver).Count(productName), 1);
        }

        [Then(@"name, color, size, quantity, price and total price is displayed correctly for double item")]
        public void ThenNameColorSizeQuantityPriceAndTotalPriceIsDisplayedCorrectlyForDoubleItem()
        {
            Assert.AreEqual(new CartPageObject(_driver).GetItemInfo(), TestSettings.InfoProducts);
        }

        [Then(@"the '(.*)' item page is opened")]
        public void ThenTheItemPageIsOpened(string pageName)
        {
            Assert.IsTrue(new ItemPageObject(_driver).CheckPageTitle(pageName));
        }

    }
}
