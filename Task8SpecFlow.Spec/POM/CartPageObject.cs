﻿using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Task8SpecFlow.Spec.POM
{
    public class CartPageObject
    {
        private IWebDriver _webdriver;
        private HeaderPageObject Header;

        public CartPageObject(IWebDriver webdriver)
        {
            _webdriver = webdriver;
            Header = new HeaderPageObject(webdriver);
            PageFactory.InitElements(_webdriver, this);
        }

        [FindsBy(How = How.XPath, Using = ".//tr[1]/td[@class = 'cart_total']/span")]
        [CacheLookup]
        public IWebElement FirstItemPriceTotalInCart { get; set; }

        [FindsBy(How = How.XPath, Using = ".//tr[1]/td/small/a")]
        [CacheLookup]
        public IWebElement FirstItemOptionsInCart { get; set; }

        [FindsBy(How = How.XPath, Using = ".//tr[1]/td/input[2]")]
        [CacheLookup]
        public IWebElement FirstItemQtyInCart { get; set; }

        [FindsBy(How = How.XPath, Using = ".//tr[1]/td/p[@class='product-name']/a")]
        [CacheLookup]
        public IWebElement FirstItemNameInCart { get; set; }


        [FindsBy(How = How.XPath, Using = ".//tr[1]/td/span/span")]
        [CacheLookup]
        public IWebElement FirstItemUnitPriceInCart { get; set; }

        [FindsBy(How = How.XPath, Using = ".//tr[2]/td/small/a")]
        [CacheLookup]
        public IWebElement SecondItemOptionsInCart { get; set; }

        [FindsBy(How = How.XPath, Using = ".//tr[2]/td[@class = 'cart_total']/span")]
        [CacheLookup]
        public IWebElement SecondItemPriceTotalInCart { get; set; }

        [FindsBy(How = How.XPath, Using = ".//tr[2]/td/input[2]")]
        [CacheLookup]
        public IWebElement SecondItemQtyInCart { get; set; }

        [FindsBy(How = How.XPath, Using = ".//tr[2]/td/p[@class='product-name']/a")]
        [CacheLookup]
        public IWebElement SecondItemNameInCart { get; set; }


        [FindsBy(How = How.XPath, Using = ".//tr[2]/td/span/span")]
        [CacheLookup]
        public IWebElement SecondItemUnitPriceInCart { get; set; }


        private string GetItemInfo()
        {
            return FirstItemNameInCart.Text.Trim() + FirstItemOptionsInCart.Text + FirstItemQtyInCart.Text + FirstItemUnitPriceInCart.Text.TrimStart('$') + FirstItemPriceTotalInCart.Text.TrimStart('$')+
                SecondItemNameInCart.Text.Trim() + SecondItemOptionsInCart.Text + SecondItemQtyInCart.Text + SecondItemUnitPriceInCart.Text.TrimStart('$') + SecondItemPriceTotalInCart.Text.TrimStart('$');
        }

        public bool MatchDataFirstProductItem()
        {
            return FirstItemNameInCart.Text.Trim() == TestSettings.FirstItemName.Trim() && FirstItemPriceTotalInCart.Text.Trim() == TestSettings.FirstItemPrice.Trim();
        }

        [System.Obsolete]
        public bool MatchDataInCart()
        {
            WaitUntil.WaitSomeInterval();
            return GetItemInfo() == TestSettings.InfoProducts;
        }

        public void DeleteItemFromCart(string name)
        {
            IWebElement delete = _webdriver.FindElement(By.XPath($".//tr[1]/td/p[@class='{name.Trim()}']/a/ancestor::tr/td[@data-title='Delete']/div/a/i"));
            delete.Click();
        }
    }
}
