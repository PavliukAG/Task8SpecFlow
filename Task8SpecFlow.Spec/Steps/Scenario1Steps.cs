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
            new FirstPageObject(_driver).FindQueryInSearch();
        }        

        [Then(@"the search query (.*) is displayed in the resualt page")]
        public void ThenTheSearchQueryIsDisplayedInTheResualtPage(string search_resualt)
        {           
            Assert.IsTrue(new CatalogPageObject(_driver).CheckSearchText(search_resualt), "Searching is not correct!");
        }

        [When(@"open dropdown sorting select the (.*) option")]
        public void WhenOpenDropdownSortingSelectTheOption(string typeSort)
        {
            new CatalogPageObject(_driver).Sorting(typeSort);
        }

        [Then(@"items on the page are sorted according to the selected option")]
        public void ThenItemsOnThePageAreSortedAccordingToTheSelectedOption()
        {           
            Assert.IsTrue(new CatalogPageObject(_driver).CheckSort(), "Incorrect sorting price item!");
        }
        [Given(@"save information about the first item")]
        public void GivenSaveInformationAboutTheFirstItem()
        {            
            Assert.IsTrue(new CatalogPageObject(_driver).SaveInfoFirstItem());
        }

        [When(@"go to cart")]
        public void WhenGoToCart()
        {
            new CatalogPageObject(_driver).OpenCartPage();
        }


        [Then(@"the item data matches the item data in the cart")]
        public void ThenTheItemDataMatchesTheItemDataInTheCart()
        {            
            Assert.IsTrue(new CartPageObject(_driver).MatchDataFirstProductItem());
        }


    }
}
