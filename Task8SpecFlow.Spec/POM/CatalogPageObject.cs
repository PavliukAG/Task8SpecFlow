using System;
using OpenQA.Selenium;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using SeleniumExtras.PageObjects;
using Task8SpecFlow.Spec.POM;
using OpenQA.Selenium.Interactions;

namespace Task8SpecFlow.Spec.POM
{
    public class CatalogPageObject
    {
        private IWebDriver _webdriver;
        private HeaderPageObject Header;

        public CatalogPageObject(IWebDriver webdriver)
        { 
            _webdriver = webdriver;
            Header = new HeaderPageObject(webdriver);
            PageFactory.InitElements(_webdriver, this);
        }

        [FindsBy(How = How.XPath, Using = ".//div[@id='uniform-selectProductSort']")]
        [CacheLookup]
        public IWebElement SelectSortButton { get; set; }

        [FindsBy(How = How.XPath, Using = ".//select[@id='selectProductSort']/option[contains(text(),'Price: Highest')]")]
        [CacheLookup]
        public IWebElement TypeSortPriceHighestButton { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='layer_cart']//a[@title='Proceed to checkout']/span")]
        [CacheLookup]
        public IWebElement CheckoutCart { get; set; }


        [FindsBy(How = How.XPath, Using = ".//ul[contains(@class, 'product_list')]//li[1]//div[@class='right-block']//span[@itemprop='price']")]
        [CacheLookup]
        public IWebElement FirstProductItemPrice { get; set; }


        [FindsBy(How = How.XPath, Using = ".//ul[contains(@class, 'product_list')]//li[1]//a[@class='product-name']")]
        [CacheLookup]
        public IWebElement FirstProductItemName { get; set; }


        [FindsBy(How = How.XPath, Using = ".//li[1]/div[@class='product-container']")]
        [CacheLookup]
        public IWebElement FirstProductItem { get; set; }


        [FindsBy(How = How.CssSelector, Using = ".lighter")]
        [CacheLookup]
        public IWebElement SearchLighter { get; set; }

        [Obsolete]
        public void Sorting(string typeSort)
        {
            WaitUntil.WaitElement(_webdriver, SelectSortButton);
            SelectSortButton.Click();
            IWebElement TypeSortPrice = _webdriver.FindElement(By.XPath($".//select[@id='selectProductSort']/option[text()='{typeSort}']"));
            WaitUntil.WaitElement(_webdriver, TypeSortPrice);
            TypeSortPrice.Click();
        }

        [Obsolete]
        public void MoveThenClickButton(string buttonName)
        {
            IWebElement spanButton = _webdriver.FindElement(By.XPath($".//span[text()='{buttonName}']"));
            //WaitUntil.WaitElement(_webdriver, spanButton);
            Actions action = new Actions(_webdriver);
            action.MoveToElement(FirstProductItem).Click(spanButton).Build().Perform();
        }

        [Obsolete]
        public void OpenCartPage()
        {
            WaitUntil.WaitElement(_webdriver, CheckoutCart);
            CheckoutCart.Click();
        }

        [Obsolete]
        public Boolean CheckSearchText(string search_resualt)
        {
            WaitUntil.WaitElement(_webdriver, SearchLighter);
            search_resualt = search_resualt.ToUpper().Trim();
            string search = SearchLighter.Text.Trim();
            return search_resualt.Contains(search);
        }

        [Obsolete]
        public Boolean SaveInfoFirstItem()
        {
            WaitUntil.WaitElement(_webdriver, FirstProductItem);
            TestSettings.FirstItemName = FirstProductItemName.Text.Trim();
            TestSettings.FirstItemPrice = FirstProductItemPrice.Text.Trim();
            return (TestSettings.FirstItemName.Length > 0 && TestSettings.FirstItemPrice.Length > 0);
        }

        public List<Decimal> GetListPrice()
        {
            List<Decimal> listItem = new List<decimal>();
            IList<IWebElement> PriceItem = _webdriver.FindElements(By.XPath(".//div[@class = 'right-block']//span[ @class = 'old-price product-price']  | .//div[@class = 'right-block']//span[ @class = 'price product-price' and not(./following-sibling::span[@class='old-price product-price'])]"));
            foreach (IWebElement element in PriceItem)
            {
                listItem.Add(Decimal.Parse(element.Text.TrimStart('$')));
            }
            return listItem;
        }
       
        public bool CheckSort()
        {
            var actualSortData = GetListPrice();
            var expectedSortData = actualSortData.OrderByDescending(x => x );
            return actualSortData.SequenceEqual(expectedSortData);
        }

    }
}
