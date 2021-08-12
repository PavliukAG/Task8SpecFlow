using OpenQA.Selenium;
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


        public string GetItemInfo()
        {
            return FirstItemNameInCart.Text +" " + FirstItemOptionsInCart.Text + FirstItemQtyInCart.GetAttribute("value") + FirstItemUnitPriceInCart.Text.TrimStart('$') + FirstItemPriceTotalInCart.Text.TrimStart('$')+
              SecondItemNameInCart.Text + " " +  SecondItemOptionsInCart.Text + SecondItemQtyInCart.GetAttribute("value") + SecondItemUnitPriceInCart.Text.TrimStart('$') + SecondItemPriceTotalInCart.Text.TrimStart('$');
        }

        public bool MatchDataFirstProductItem()
        {
            return FirstItemNameInCart.Text.Trim() == TestSettings.FirstItemName.Trim() && FirstItemPriceTotalInCart.Text.Trim() == TestSettings.FirstItemPrice.Trim();
        }

        [System.Obsolete]
        public string MatchDataInCart()
        {
            WaitUntil.WaitSomeInterval();
            return GetItemInfo();
        }

        public void DeleteItemFromCart(string name)
        {
            IWebElement delete = _webdriver.FindElement(By.XPath($".//tr/td/p[@class='product-name']/a[text()='{name}']/ancestor::tr/td[@data-title='Delete']/div/a/i"));
            delete.Click();
            _webdriver.Navigate().Refresh();
        }

        public bool IsExist(string itemName)
        {
            return _webdriver.FindElement(By.XPath($".//td/p[@class='product-name']/a[text()='{itemName}']")).Displayed;
        }

        public int Count()
        {
            return _webdriver.FindElements(By.XPath($".//td/p[@class='product-name']/a")).Count;
        }
    }
}
