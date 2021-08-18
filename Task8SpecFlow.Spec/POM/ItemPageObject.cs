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

        [FindsBy(How = How.XPath, Using = "//div[@id='layer_cart']/div[@class='clearfix']")]
        [CacheLookup]
        public IWebElement ModuleWindow { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[contains(@class, 'layer_cart_product ')]/h2")]
        [CacheLookup]
        public IWebElement TitleModuleWindow { get; set; }

        private string locatorSize(string size) => $".//*[@id='group_1']/option[text()='{size}']";
        private string locatorColor(string color) => $".//a[@name='{color}']";
        private string locatorItemButton(string buttonName) => $".//*[text()='{buttonName}']";
        private string locatorButtonInModuleWindow(string nameBtn) => $".//*[@class='button-container']/*[contains(@title, '{nameBtn}')]";
         


        public void ChooseQnt(string qty)
        {
            qty = qty.Trim();
            QtyField.Clear();
            QtyField.SendKeys(qty);
        }

      
        public void ChooseSize(string size) 
        {
            size = size.Trim().ToUpper();
            IWebElement sizeOption = _webdriver.FindElement(By.XPath(locatorSize(size)));
            SizeField.Click();
            WaitUntil.WaitElement(_webdriver, sizeOption);
            sizeOption.Click();            
        }

        public void ChooseColor(string color)
        {
            color = color.Trim();
            IWebElement colorOption = _webdriver.FindElement(By.XPath(locatorColor(color)));
            colorOption.Click();
        }

        public decimal GetItemPrice()
        {
            return decimal.Parse(PriceItemField.Text.TrimStart('$'));
        }

     
        public void ClickButtonItemPage(string buttonName)
        {
            IWebElement Button = _webdriver.FindElement(By.XPath(locatorItemButton(buttonName)));
            WaitUntil.WaitElement(_webdriver, Button);
            Button.Click();
        }

        public string GetItemName()
        {
            return ItemName.Text;
        }

 
        public Boolean CheckModuleTitle(string title)
        {
            WaitUntil.WaitElement(_webdriver, ModuleWindow);
            title = title.Trim();
            return TitleModuleWindow.Text.Trim() == title;
        }

        
        public void ClickButtonInModuleWindow(string nameBtn)
        {
            IWebElement Button = _webdriver.FindElement(By.XPath(locatorButtonInModuleWindow(nameBtn)));
            WaitUntil.WaitElement(_webdriver, Button);
            Button.Click();
        }


        public Boolean CheckPageTitle(string pageName)
        {
            return _webdriver.Title.Contains(pageName);
        }
    }
}
