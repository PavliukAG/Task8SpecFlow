using System;
using TechTalk.SpecFlow;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using Microsoft.Edge.SeleniumTools;
using BoDi;

namespace Task8SpecFlow.Spec.Hooks
{
    [Binding]
    public sealed class ShopSiteHooks
    {
        private readonly IObjectContainer _objectContainer;

        private IWebDriver _driverChrome;
        private IWebDriver _driverFox;
        private IWebDriver _driverEdge;


        public ShopSiteHooks(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
        }

        [BeforeScenario("Chrome", Order = 1)]
        public void BeforeScenarioChrome()
        {
            SelectBrowser(BrowserType.Chrome);
        }


        [BeforeScenario("Firefox", Order = 2)]
        public void BeforeScenarioFirefox()
        {
            SelectBrowser(BrowserType.Firefox);
        }

        [BeforeScenario("Edge", Order = 3)]
        public void BeforeScenarioEdge()
        {
            
            SelectBrowser(BrowserType.Edge);
        }

        
        [AfterScenario("Chrome")]
        public void AfterScenatioC()
        {
            DoAfterEach(_driverChrome);
            _driverChrome.Quit();
            _driverChrome.Dispose();
        }



        [AfterScenario("Firefox")]
        public void AfterScenatioF()
        {
            DoAfterEach(_driverFox);
            _driverFox.Quit();
            _driverFox.Dispose();
        }


        [AfterScenario("Edge")]
        public void AfterScenatioE()
        {
            DoAfterEach(_driverEdge);
            _driverEdge.Quit();
            _driverEdge.Dispose();
        }



        public void DoAfterEach(IWebDriver _driver)
        {
            DateTime time = DateTime.Now;
            string dateToday = "_date_" + time.ToString("yyyy-MM-dd") + "_time_" + time.ToString("HH-mm-ss");

            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            {
                var screenshot = ((ITakesScreenshot)_driver).GetScreenshot();
                screenshot.SaveAsFile("FAIL" + dateToday + "Screenshot.png");
            }
        }
        internal void SelectBrowser(BrowserType browserType)
        {
            switch (browserType)
            {
                case BrowserType.Chrome:                  
                    _driverChrome = new ChromeDriver(Environment.CurrentDirectory);
                    _driverChrome.Manage().Window.Maximize();
                    _objectContainer.RegisterInstanceAs<IWebDriver>(_driverChrome);
                    break;
                case BrowserType.Firefox:
                    _driverFox = new FirefoxDriver(Environment.CurrentDirectory);
                    _driverFox.Manage().Window.Maximize();
                    _objectContainer.RegisterInstanceAs<IWebDriver>(_driverFox);
                    break;
                case BrowserType.Edge:
                    var option = new EdgeOptions();
                    option.UseChromium = true;
                    _driverEdge = new EdgeDriver(Environment.CurrentDirectory, option);
                    _driverEdge.Manage().Window.Maximize();
                    _objectContainer.RegisterInstanceAs<IWebDriver>(_driverEdge);
                    break;
                default:
                    break;
            }
        }

    }

    enum BrowserType
    {
        Chrome,
        Firefox,
        Edge
    }

}

