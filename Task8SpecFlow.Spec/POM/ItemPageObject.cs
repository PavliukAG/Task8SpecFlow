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

        public void ChooseQnt(string qty)
        {
            qty = qty.Trim();
            QtyField.Clear();
            QtyField.SendKeys(qty);
            //return QtyField.Text==qty;
        }

        [Obsolete]
        public void ChooseSize(string size) 
        {
            size = size.Trim().ToUpper();
            IWebElement sizeOption = _webdriver.FindElement(By.XPath($".//*[@id='group_1']/option[text()='{size}']"));
            SizeField.Click();
            WaitUntil.WaitElement(_webdriver, sizeOption);
            sizeOption.Click();            
           // return _webdriver.FindElement(By.XPath($".//div[@id='uniform-group_1']/span")).Text.Trim() == size;
        }

        public void ChooseColor(string color)
        {
            color = color.Trim();
            IWebElement colorOption = _webdriver.FindElement(By.XPath($".//a[@name='{color}']"));
            colorOption.Click();
            //return _webdriver.FindElement(By.XPath(".//li[@class='selected']/a")).GetAttribute("name") == color;
        }

        public decimal GetItemPrice()
        {
            return decimal.Parse(PriceItemField.Text.TrimStart('$'));
        }

    }
}
