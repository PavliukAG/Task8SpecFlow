using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Task8SpecFlow.Spec.POM
{
    public class FirstPageObject
    {
        private IWebDriver _webdriver;
        private HeaderPageObject Header;

        public FirstPageObject(IWebDriver webdriver)
        { 
            _webdriver = webdriver;
            Header = new HeaderPageObject(_webdriver);
            PageFactory.InitElements(_webdriver, this);
        }

        public void InputQueryInSearch(string search_query)
        {
            Header.InputSearchWord(search_query);
        }

        public void FindQueryInSearch()
        {
            Header.ClickOnSearchingButton();
        }

    }
}
