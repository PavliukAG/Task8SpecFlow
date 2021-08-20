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

        private string locatorUnitPrice(string itemName) => $"//tr/td/p[@class='product-name']/a[text()='{itemName}']/ancestor::tr/td/span/span";
        private string locatorTotalPrice(string itemName) => $"//tr/td/p[@class='product-name']/a[text()='{itemName}']/ancestor::tr/td[@class = 'cart_total']/span";
        private string locatorQty(string itemName) => $"//tr/td/p[@class='product-name']/a[text()='{itemName}']/ancestor::tr/td/input[contains(@class, 'cart_quantity_input')]";
        private string locatorOptions(string itemName) => $"//tr/td/p[@class='product-name']/a[text()='{itemName}']/ancestor::tr/td/small/a";
        private string locatorName(string itemName) => $"//td/p[@class='product-name']/a[text()='{itemName}']";
        private string locatorNameForDelete(string itemName) => $".//tr/td/p[@class='product-name']/a[text()='{itemName}']/ancestor::tr/td[@data-title='Delete']/div/a/i";


        public string GetItemInfo()
        {
            return _webdriver.FindElement(By.XPath(locatorName(TestSettings.FirstName))).Text +" " 
                + _webdriver.FindElement(By.XPath(locatorOptions(TestSettings.FirstName))).Text 
                + _webdriver.FindElement(By.XPath(locatorQty(TestSettings.FirstName))).GetAttribute("value") 
                + _webdriver.FindElement(By.XPath(locatorUnitPrice(TestSettings.FirstName))).Text.TrimStart('$') 
                + _webdriver.FindElement(By.XPath(locatorTotalPrice(TestSettings.FirstName))).Text.TrimStart('$')+
              _webdriver.FindElement(By.XPath(locatorName(TestSettings.SecondName))).Text + " " 
              + _webdriver.FindElement(By.XPath(locatorOptions(TestSettings.SecondName))).Text 
              + _webdriver.FindElement(By.XPath(locatorQty(TestSettings.SecondName))).GetAttribute("value") 
              + _webdriver.FindElement(By.XPath(locatorUnitPrice(TestSettings.SecondName))).Text.TrimStart('$') 
              + _webdriver.FindElement(By.XPath(locatorTotalPrice(TestSettings.SecondName))).Text.TrimStart('$');
        }

        public bool MatchDataFirstProductItem()
        {
            return FirstItemNameInCart.Text.Trim() == TestSettings.FirstItemName.Trim() && FirstItemPriceTotalInCart.Text.Trim() == TestSettings.FirstItemPrice.Trim();
        }


        public void DeleteItemFromCart(string name)
        {
            IWebElement delete = _webdriver.FindElement(By.XPath(locatorNameForDelete(name)));
            delete.Click();
            _webdriver.Navigate().Refresh();
        }

        public bool IsExist(string itemName)
        {
            return _webdriver.FindElement(By.XPath(locatorName(itemName))).Displayed;
        }

        public int Count(string itemName)
        {
            return _webdriver.FindElements(By.XPath(locatorName(itemName))).Count;
        }
    }
}
