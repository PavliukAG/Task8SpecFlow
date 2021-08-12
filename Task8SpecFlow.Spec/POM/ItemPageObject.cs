using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Task8SpecFlow.Spec.POM
{
    public class ItemPageObject
    {
        private IWebDriver _webdriver;
        private HeaderPageObject Header;

        public ItemPageObject(IWebDriver webdriver)
        {
            _webdriver = webdriver;
            Header = new HeaderPageObject(webdriver);
            PageFactory.InitElements(_webdriver, this);
        }

        [FindsBy(How = How.XPath, Using = ".//span[@itemprop='price']")]
        [CacheLookup]
        public IWebElement PriceItemField { get; set; }

        [FindsBy(How = How.XPath, Using = ".//input[@name='qty']")]
        [CacheLookup]
        public IWebElement QtyField { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='group_1']")]
        [CacheLookup]
        public IWebElement SizeField { get; set; }

        [FindsBy(How = How.XPath, Using = ".//div[@class='right-block']//div[@itemprop='offers']")]
        [CacheLookup]
        public IWebElement ColorField { get; set; }

        [FindsBy(How = How.XPath, Using = ".//h1[@itemprop='name']")]
        [CacheLookup]
        public IWebElement ItemName { get; set; }



        public void ChooseQnt(string qty)
        {
            qty = qty.Trim();
            QtyField.Clear();
            QtyField.SendKeys(qty);
        }



        [Obsolete]
        public void ChooseSize(string size) 
        {
            size = size.Trim().ToUpper();
            IWebElement sizeOption = _webdriver.FindElement(By.XPath($".//*[@id='group_1']/option[text()='{size}']"));
            SizeField.Click();
            WaitUntil.WaitElement(_webdriver, sizeOption);
            sizeOption.Click();            
        }

        public void ChooseColor(string color)
        {
            color = color.Trim();
            IWebElement colorOption = _webdriver.FindElement(By.XPath($".//a[@name='{color}']"));
            colorOption.Click();
        }

        public decimal GetItemPrice()
        {
            return decimal.Parse(PriceItemField.Text.TrimStart('$'));
        }

        [Obsolete]
        public void ClickButtonItemPage(string buttonName)
        {
            IWebElement Button = _webdriver.FindElement(By.XPath($".//*[text()='{buttonName}']"));
            WaitUntil.WaitElement(_webdriver, Button);
            Button.Click();
        }

        public string GetItemName()
        {
            return ItemName.Text;
        }

        [Obsolete]
        public Boolean CheckModuleTitle(string title)
        {
            IWebElement element = _webdriver.FindElement(By.XPath(".//div[@id='layer_cart']/div[@class='clearfix']"));
            WaitUntil.WaitElement(_webdriver, element);
            title = title.Trim();
            return _webdriver.FindElement(By.XPath($".//div[contains(@class, 'layer_cart_product ')]/h2")).Text.Trim() == title;
        }

        [Obsolete]
        public void ClickButton(string nameBtn)
        {
            IWebElement Button = _webdriver.FindElement(By.XPath($".//*[@class='button-container']/*[contains(@title, '{nameBtn}')]"));
            WaitUntil.WaitElement(_webdriver, Button);
            Button.Click();
        }
    }
}
