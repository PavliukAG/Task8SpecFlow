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
        private CartPageObject _cartPageObject;
        private ItemPageObject _itemPageObject;
        private CatalogPageObject _catalogPageObject;
        public Scenario2Steps(IWebDriver driver)
        {

           
            _driver = driver;
            _cartPageObject = new CartPageObject(_driver);
            _catalogPageObject = new CatalogPageObject(_driver);
            _itemPageObject = new ItemPageObject(_driver);
        }

        [Given(@"the search query (.*) is displayed in the resualt page")]
        public void GivenTheSearchQueryIsDisplayedInTheResualtPage(string namePage)
        {
            Assert.IsTrue(_catalogPageObject.CheckSearchText(namePage), "Searching is not correct!");
        }

        [When(@"move and click ""(.*)"" button")]
        public void WhenMoveAndClickButton(string buttonName)
        {
            new CatalogPageObject(_driver).MoveThenClickButton(buttonName);
        }
        
        
        [Then(@"modal window with a title ""(.*)"" is displayed")]
        public void ThenModalWindowWithATitleIsDisplayed(string title)
        {
            Assert.IsTrue(_itemPageObject.CheckModuleTitle(title), "Title in module windows is incorrect!");
        }

        [When(@"choose conditions for Quantity = '(.*)', Size = '(.*)', Color = '(.*)'")]
        public void WhenChooseConditionsForQuantitySizeColor(string qty, string size, string color)
        {
            _itemPageObject = new ItemPageObject(_driver);
            TestSettings.InfoProducts = TestSettings.InfoProducts + _itemPageObject.GetItemName()+ " Color : " + color.Trim() + ", Size : " + size.Trim() + qty + _itemPageObject.GetItemPrice() + decimal.Parse(qty.Trim())* _itemPageObject.GetItemPrice();

            _itemPageObject.ChooseQnt(qty);
            _itemPageObject.ChooseSize(size);
            _itemPageObject.ChooseColor(color);
        }
        
        [When(@"delete item '(.*)' from cart")]
        public void WhenDeleteItemFromCart(string productName)
        {
            _cartPageObject.DeleteItemFromCart(productName);
        }

        [Then(@"click ""(.*)"" button")]
        public void ThenClickButton(string buttonName)
        {
            _itemPageObject.ClickButtonInModuleWindow(buttonName);
        }

        [When(@"click ""(.*)"" button")]
        public void WhenClickButton(string buttonName)
        {
            _itemPageObject.ClickButtonItemPage(buttonName);
        }

     
        [Then(@"only item '(.*)' is displayed in cart")]
        public void ThenOnlyItemIsDisplayedInCart(string productName)
        {
            Assert.IsTrue(_cartPageObject.IsExist(productName));
            Assert.AreEqual(_cartPageObject.Count(productName), 1);
        }

        [Then(@"name, color, size, quantity, price and total price is displayed correctly for double item")]
        public void ThenNameColorSizeQuantityPriceAndTotalPriceIsDisplayedCorrectlyForDoubleItem()
        {
            Assert.AreEqual(_cartPageObject.GetItemInfo(), TestSettings.InfoProducts);
        }

        [Then(@"the '(.*)' item page is opened")]
        public void ThenTheItemPageIsOpened(string pageName)
        {
            
            Assert.IsTrue(_itemPageObject.CheckPageTitle(pageName));
        }

    }
}
