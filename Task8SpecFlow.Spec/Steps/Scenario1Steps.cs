using System;
using TechTalk.SpecFlow;
using Task8SpecFlow.Spec.POM;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using System.Collections.Generic;

namespace Task8SpecFlow.Spec.Steps
{
    [Binding]
    public class Scenario1Steps
    {

        private IWebDriver _driver;
        public Scenario1Steps(IWebDriver driver)
        {
            _driver = driver;           
        }

        /// <summary>
        /// Scenario 1
        /// </summary>

        [Given(@"the shopping page is opened")]
        public void GivenTheShoppingPageIsOpened()
        {
            _driver.Navigate().GoToUrl(TestSettings.MainUrl);
        }
        
        [When(@"in the search field, enter the keyword: (.*)")]
        public void WhenInTheSearchFieldEnterTheKeyword(string search_query)
        {
            new FirstPageObject(_driver).InputQueryInSearch(search_query);
        }

        [When(@"click the search icon")]
        public void WhenClickTheSearchIcon()
        {
            FirstPageObject firstPageObject = new FirstPageObject(_driver);
            firstPageObject.FindQueryInSearch();
        }
        

        [Then(@"the search query (.*) is displayed in the resualt page")]
        [Obsolete]
        public void ThenTheSearchQueryIsDisplayedInTheResualtPage(string search_resualt)
        {
            CatalogPageObject catalogPageObject = new CatalogPageObject(_driver);
            Assert.IsTrue(catalogPageObject.CheckSearchText(search_resualt), "Searching is not correct!");
            //TestSettings.CurrentUrl = _driver.Url;
        }




        /// <summary>
        /// Scenario 2
        /// </summary>

        [Given(@"product catalog page is opened")]
        public void GivenProductCatalogPageIsOpened()
        {
            _driver.Navigate().GoToUrl(TestSettings.CurrentUrl);
        }

        [When(@"open dropdown sorting select the (.*) option")]
        [Obsolete]
        public void WhenOpenDropdownSortingSelectTheOption(string typeSort)
        {
            new CatalogPageObject(_driver).Sorting(typeSort);
        }


        [Then(@"items on the page are sorted according to the selected option")]
        public void ThenItemsOnThePageAreSortedAccordingToTheSelectedOption()
        {
            CatalogPageObject catalogPage = new CatalogPageObject(_driver);
            Assert.That(catalogPage.CheckSort(), "Incorrect sorting price item!");
            TestSettings.CurrentUrl = _driver.Url;
        }



        /// <summary>
        /// Scenario 3
        /// </summary>
        [Given(@"save information about the first item")]
        [Obsolete]
        public void GivenSaveInformationAboutTheFirstItem()
        {
           _driver.Navigate().GoToUrl(TestSettings.CurrentUrl);
            Assert.IsTrue(new CatalogPageObject(_driver).SaveInfoFirstItem());
        }

        [When(@"go to cart")]
        [Obsolete]
        public void WhenGoToCart()
        {
            new CatalogPageObject(_driver).OpenCartPage();
        }


        [Then(@"the item data matches the item data in the cart")]
        [Obsolete]
        public void ThenTheItemDataMatchesTheItemDataInTheCart()
        {
             CartPageObject cartPageObject = new CartPageObject(_driver);
            Assert.IsTrue(cartPageObject.MatchDataFirstProductItem());
            TestSettings.CurrentUrl = _driver.Url;
        }


    }
}
