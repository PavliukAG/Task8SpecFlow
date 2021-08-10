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

        [Given(@"the search query '(.*)' is displayed in the resualt page")]
        [Obsolete]
        public void GivenTheSearchQueryIsDisplayedInTheResualtPage(string namePage)
        {
            TestSettings.InfoProducts = TestSettings.InfoProducts + namePage;
            //string Url = $"http://automationpractice.com/index.php?controller=search&search_query={namePage}&submit_search=&orderby=position&orderway=asc";
            //_driver.Navigate().GoToUrl(TestSettings.CurrentUrl);
            CatalogPageObject catalogPageObject = new CatalogPageObject(_driver);
            //Assert.IsTrue(catalogPageObject.CheckSearchText(namePage), $"Searching is not correct! {Url}");
        }

        [Given(@"the item page is opened")]
        public void GivenTheItemPageIsOpened()
        {
            //string Url = $"http://automationpractice.com/index.php?controller=search&search_query=Blouse&submit_search=&orderby=position&orderway=asc";
           // _driver.Navigate().GoToUrl(Url);
        }


        [Given(@"the cart page is opened")]
        public void GivenTheCartPageIsOpened()
        {
           // _driver.Navigate().GoToUrl(TestSettings.CurrentUrl);
            Assert.That(false, $"Item in cart {_driver.FindElement(By.XPath("//*[@id='summary_products_quantity']")).Text}");
            //_driver.Navigate().GoToUrl(TestSettings.CartPageUrl);
        }
        
        [When(@"move and click ""(.*)"" button")]
        [Obsolete]
        public void WhenMoveAndClickButton(string buttonName)
        {
            new CatalogPageObject(_driver).ButtonItemContainer(buttonName);
           /* IWebElement spanButton = _driver.FindElement(By.XPath($".//span[text()={buttonName}]"));
            spanButton.Click();*/
        }
        
        
        [When(@"modal window with a title ""(.*)"" is displayed")]
        [Obsolete]
        public void WhenModalWindowWithATitleIsDisplayed(string title)
        {
            IWebElement element = _driver.FindElement(By.XPath(".//div[@id='layer_cart']/div[@class='clearfix']"));
            WaitUntil.WaitElement(_driver, element);
            ItemModulePageObject itemModule = new ItemModulePageObject(_driver);
            Assert.That(itemModule.CheckModuleTitle(title), "Title in module windows is incorrect!");
        }

        [When(@"choose conditions for Quantity = '(.*)', Size = '(.*)', Color = '(.*)'")]
        public void WhenChooseConditionsForQuantitySizeColor(string qty, string size, string color)
        {
            ItemPageObject itemPageObject = new ItemPageObject(_driver);
            // IWebDriver driver = ScenarioContext.Current.Get<IWebDriver>("Driver");
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
            IWebElement Button = _driver.FindElement(By.XPath($".//*[@class='button-container']//*[contains(*, '{buttonName}')]"));
            WaitUntil.WaitElement(_driver, Button);
            Button.Click();
            WaitUntil.WaitSomeInterval(30);
            //TestSettings.CurrentUrl = _driver.Url;
        }

        [When(@"click ""(.*)"" button")]
        [Obsolete]
        public void WhenClickButton(string buttonName)
        {
            IWebElement Button = _driver.FindElement(By.XPath($".//*[text()='{buttonName}']"));
            WaitUntil.WaitElement(_driver, Button);
            Button.Click();
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
        public void ThenNameColorSizeQuantityPriceAndTotalPriceIsDisplayedCorrectlyForDoubleItem()
        {
           // _driver.Navigate().GoToUrl(TestSettings.CurrentUrl);
            CartPageObject cartPage = new CartPageObject(_driver);
            Assert.IsTrue(cartPage.MatchDataInCart(), "Data in cart is not matching!");
            //TestSettings.CurrentUrl = _driver.Url;
        }

    }
}
