using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
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
            /*_driverHelper = driverHelper;
            firstPageObject = new FirstPageObject(driverHelper.Driver);
            catalogPageObject = new CatalogPageObject(driverHelper.Driver);*/
        }

        [Given(@"the search query (.*) is displayed in the resualt page")]
        [Obsolete]
        public void GivenTheSearchQueryIsDisplayedInTheResualtPage(string namePage)
        {
            _driver.Navigate().GoToUrl(TestSettings.CurrentUrl);
            TestSettings.InfoProducts = TestSettings.InfoProducts + namePage;
            CatalogPageObject catalogPageObject = new CatalogPageObject(_driver);
            Assert.IsTrue(catalogPageObject.CheckSearchText(namePage), "Searching is not correct!");
        }

        [Given(@"the item page is opened")]
        public void GivenTheItemPageIsOpened()
        {
            //string Url = $"http://automationpractice.com/index.php?controller=search&search_query=Blouse&submit_search=&orderby=position&orderway=asc";
            _driver.Navigate().GoToUrl(TestSettings.CurrentUrl);
        }


        [Given(@"the cart page is opened")]
        public void GivenTheCartPageIsOpened()
        {
            _driver.Navigate().GoToUrl(TestSettings.CurrentUrl);
            _driver.Navigate().Refresh();
            Assert.That(false, $"Item in cart {_driver.FindElement(By.XPath(".//*[text()='Your shopping cart is empty.']")).Text}");
            //_driver.Navigate().GoToUrl(TestSettings.CartPageUrl);
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
            ItemModulePageObject itemModule = new ItemModulePageObject(_driver);
            Assert.That(itemModule.CheckModuleTitle(title), "Title in module windows is incorrect!");
        }

        [When(@"choose conditions for Quantity = '(.*)', Size = '(.*)', Color = '(.*)'")]
        public void WhenChooseConditionsForQuantitySizeColor(string qty, string size, string color)
        {
            ItemPageObject itemPageObject = new ItemPageObject(_driver);
            TestSettings.InfoProducts = TestSettings.InfoProducts + "Color : " + color.Trim() + ", Size : " + size.Trim() + qty + itemPageObject.GetItemPrice() + decimal.Parse(qty.Trim())*itemPageObject.GetItemPrice();
            
            itemPageObject.ChooseQnt(qty);
            itemPageObject.ChooseSize(size);
            itemPageObject.ChooseColor(color);
          /*  Assert.That(itemPageObject.ChooseQnt(qty), "Incorrect quantity!");
            Assert.That(itemPageObject.ChooseSize(size), "Incorrext size!");
            Assert.That(itemPageObject.ChooseColor(color), "Incorrect color!");*/
        }
        
        [When(@"delete item '(.*)' from cart")]
        public void WhenDeleteItemFromCart(string productName)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"click ""(.*)"" button")]
        [Obsolete]
        public void ThenClickButton(string buttonName)
        {
            //_driver.Navigate().GoToUrl(TestSettings.CurrentUrl);
            IWebElement Button = _driver.FindElement(By.XPath($".//*[@class='button-container']//*[contains(*, '{buttonName}')]"));
            WaitUntil.WaitElement(_driver, Button);
            WaitUntil.WaitElement(_driver, Button);
            Button.Click();
            WaitUntil.WaitSomeInterval(30);
            TestSettings.CurrentUrl = _driver.Url;
        }

        [When(@"click ""(.*)"" button")]
        [Obsolete]
        public void WhenClickButton(string buttonName)
        {
            //Assert.That(false, $"Before click button {_driver.Url}");
            new ItemPageObject(_driver).ClickButtonItemPage(buttonName);
            

        }

     
        [Then(@"item '(.*)' is displayed in cart")]
        public void ThenItemIsDisplayedInCart(string p0)
        {
            ScenarioContext.Current.Pending();
        }


        [Then(@"the one item is displayed in the cart")]
        public void ThenTheOneItemIsDisplayedInTheCart()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"name, color, size, quantity, price and total price is displayed correctly for double item")]
        [Obsolete]
        public void ThenNameColorSizeQuantityPriceAndTotalPriceIsDisplayedCorrectlyForDoubleItem()
        {
            //_driver.Navigate().GoToUrl(TestSettings.CurrentUrl);
            CartPageObject cartPage = new CartPageObject(_driver);
            Assert.IsTrue(cartPage.MatchDataInCart(), "Data in cart is not matching!");
            TestSettings.CurrentUrl = _driver.Url;
        }

    }
}
