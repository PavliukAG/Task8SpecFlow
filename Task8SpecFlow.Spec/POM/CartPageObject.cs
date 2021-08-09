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

        [FindsBy(How = How.XPath, Using = ".//td[@class = 'cart_total']/span[1]")]
        [CacheLookup]
        public IWebElement FirstItemPriceInCart { get; set; }

        [FindsBy(How = How.XPath, Using = ".//td/p[@class='product-name']/a")]
        [CacheLookup]
        public IWebElement FirstItemNameInCart { get; set; }

        public bool MatchDataFirstProductItem()
        {
            return FirstItemNameInCart.Text.Trim() == TestSettings.FirstItemName.Trim() && FirstItemPriceInCart.Text.Trim() == TestSettings.FirstItemPrice.Trim();
        }
    }
}
