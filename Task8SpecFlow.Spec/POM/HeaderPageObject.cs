using OpenQA.Selenium;
using SeleniumExtras.PageObjects;


namespace Task8SpecFlow.Spec.POM
{
    public class HeaderPageObject
    {

        private IWebDriver _webDriver;

        public HeaderPageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
            PageFactory.InitElements(webDriver, this);
        }

        [FindsBy(How = How.XPath, Using = "//*[@placeholder='Search']")]
        [CacheLookup]
        public IWebElement SearchPlaceholder { get; set; }


        [FindsBy(How = How.XPath, Using = "//form[@id='searchbox']//button[@name='submit_search']")]
        [CacheLookup]
        public IWebElement SearchSubmit { get; set; }


        [FindsBy(How = How.XPath, Using = "//b[text()='Cart']")]
        [CacheLookup]
        public IWebElement CartButton { get; set; }


        public void OpenCartPage()
        {
            CartButton.Click();
        }

        public void InputSearchWord(string search_query)
        {
            SearchPlaceholder.Clear();
            SearchPlaceholder.SendKeys(search_query);
        }

        public void ClickOnSearchingButton()
        {
            WaitUntil.WaitElement(_webDriver, SearchSubmit);
            SearchSubmit.Click();
        }
    }
}
