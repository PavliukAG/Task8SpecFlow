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
        [Obsolete]
        public void GivenTheSearchQueryIsDisplayedInTheResualtPage(string namePage)
        {
            CatalogPageObject catalogPageObject = new CatalogPageObject(_driver);
            Assert.IsTrue(catalogPageObject.CheckSearchText(namePage), "Searching is not correct!");
        }

        [When(@"move and click ""(.*)"" button")]
        [Obsolete]
        public void WhenMoveAndClickButton(string buttonName)
        {          
            new CatalogPageObject(_driver).MoveThenClickButton(buttonName);
        }
        
        
        [Then(@"modal window with a title ""(.*)"" is displayed")]
        [Obsolete]
        public void ThenModalWindowWithATitleIsDisplayed(string title)
        {
            ItemPageObject itemModule = new ItemPageObject(_driver);
            Assert.IsTrue(itemModule.CheckModuleTitle(title), "Title in module windows is incorrect!");
        }

        [When(@"choose conditions for Quantity = '(.*)', Size = '(.*)', Color = '(.*)'")]
        [Obsolete]
        public void WhenChooseConditionsForQuantitySizeColor(string qty, string size, string color)
        {
            ItemPageObject itemPageObject = new ItemPageObject(_driver);
            TestSettings.InfoProducts = TestSettings.InfoProducts + itemPageObject.GetItemName()+ " Color : " + color.Trim() + ", Size : " + size.Trim() + qty + itemPageObject.GetItemPrice() + decimal.Parse(qty.Trim())*itemPageObject.GetItemPrice();
            
            itemPageObject.ChooseQnt(qty);
            itemPageObject.ChooseSize(size);
            itemPageObject.ChooseColor(color);
        }
        
        [When(@"delete item '(.*)' from cart")]
        public void WhenDeleteItemFromCart(string productName)
        {
            new CartPageObject(_driver).DeleteItemFromCart(productName);
        }

        [Then(@"click ""(.*)"" button")]
        [Obsolete]
        public void ThenClickButton(string buttonName)
        {
            new ItemPageObject(_driver).ClickButton(buttonName);
        }

        [When(@"click ""(.*)"" button")]
        [Obsolete]
        public void WhenClickButton(string buttonName)
        {
            new ItemPageObject(_driver).ClickButtonItemPage(buttonName);
        }

     
        [Then(@"only item '(.*)' is displayed in cart")]
        public void ThenOnlyItemIsDisplayedInCart(string productName)
        {
            Assert.IsTrue(new CartPageObject(_driver).IsExist(productName));
            Assert.AreEqual(new CartPageObject(_driver).Count(), 1);
        }

        [Then(@"name, color, size, quantity, price and total price is displayed correctly for double item")]
        [Obsolete]
        public void ThenNameColorSizeQuantityPriceAndTotalPriceIsDisplayedCorrectlyForDoubleItem()
        {
            CartPageObject cartPage = new CartPageObject(_driver);
            Assert.AreEqual(cartPage.GetItemInfo(), TestSettings.InfoProducts);
        }

    }
}
