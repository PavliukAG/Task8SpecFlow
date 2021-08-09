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
            //string Url = $"http://automationpractice.com/index.php?controller=search&search_query={namePage}&submit_search=&orderby=position&orderway=asc";
            _driver.Navigate().GoToUrl(TestSettings.CurrentUrl);
            CatalogPageObject catalogPageObject = new CatalogPageObject(_driver);
            //Assert.IsTrue(catalogPageObject.CheckSearchText(namePage), $"Searching is not correct! {Url}");
        }

        [Given(@"the item page is opened")]
        public void GivenTheItemPageIsOpened()
        {
            string Url = $"http://automationpractice.com/index.php?controller=search&search_query=Blouse&submit_search=&orderby=position&orderway=asc";
            _driver.Navigate().GoToUrl(Url);
        }


        [Given(@"the cart page is opened")]
        public void GivenTheCartPageIsOpened()
        {
            _driver.Navigate().GoToUrl(TestSettings.CartPageUrl);
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
        public void WhenModalWindowWithATitleIsDisplayed(string title)
        {
            _driver.SwitchTo().ParentFrame();
            _driver.SwitchTo().Frame(_driver.FindElement(By.XPath(".//*[@id='layer_cart']")));
            ItemModulePageObject itemModule = new ItemModulePageObject(_driver);
           // Assert.That(itemModule.CheckModuleTitle(title), "Title in module windows is incorrect!");
        }

        [When(@"choose conditions for Quantity = '(.*)', Size = '(.*)', Color = '(.*)'")]
        public void WhenChooseConditionsForQuantitySizeColor(string qty, string size, string color)
        {
           // IWebDriver driver = ScenarioContext.Current.Get<IWebDriver>("Driver");
            ItemPageObject itemPageObject = new ItemPageObject(_driver);
            itemPageObject.ChooseQnt(qty);
            itemPageObject.ChooseSize(size);
            itemPageObject.ChooseColor(color);
          /*  Assert.That(itemPageObject.ChooseQnt(qty), "Incorrect quantity!");
            Assert.That(itemPageObject.ChooseSize(size), "Incorrext size!");
            Assert.That(itemPageObject.ChooseColor(color), "Incorrect color!");*/
        }

        [When(@"first name, color, size, price and quantity is displayed correctly")]
        public void WhenFirstNameColorSizePriceAndQuantityIsDisplayedCorrectly()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"second name, color, size, price and quantity is displayed correctly")]
        public void WhenSecondNameColorSizePriceAndQuantityIsDisplayedCorrectly()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"delete item '(.*)' from cart")]
        public void WhenDeleteItemFromCart(string p0)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"click ""(.*)"" button")]
        [When(@"click ""(.*)"" button")]
        [Obsolete]
        public void ThenClickButton(string buttonName)
        {
            IWebElement Button = _driver.FindElement(By.XPath($".//*[text()='{buttonName}']"));
            WaitUntil.WaitElement(_driver, Button);
            Button.Click();
            Assert.NotNull(Button, "PPPPPPROOROROO");
        }

        
        [Then(@"total price is displayed correctly")]
        public void ThenTotalPriceIsDisplayedCorrectly()
        {
            ScenarioContext.Current.Pending();
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

    }
}
