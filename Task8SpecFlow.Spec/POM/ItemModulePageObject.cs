using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Task8SpecFlow.Spec.POM
{
    public class ItemModulePageObject
    {
        private IWebDriver _webdriver;
        private HeaderPageObject Header;

        public ItemModulePageObject(IWebDriver webdriver)
        {
            _webdriver = webdriver;
            Header = new HeaderPageObject(webdriver);
            PageFactory.InitElements(_webdriver, this);
        }

        public void ClickContinueButton(string buttonName) 
        {
            buttonName = buttonName.Trim();
            _webdriver.FindElement(By.XPath($".//div[@class='button-container']/*[@title={buttonName}]")).Click();
        }

        public Boolean CheckModuleTitle(string title)
        {
            title = title.Trim();
            return _webdriver.FindElement(By.XPath($".//div[contains(@class, 'layer_cart_product ')]/h2")).Text.Trim() == title;
        }

    }
}
