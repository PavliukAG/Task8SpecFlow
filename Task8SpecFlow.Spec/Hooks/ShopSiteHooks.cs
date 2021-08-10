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

        private IWebDriver _driver;


        public ShopSiteHooks(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
        }

        [BeforeScenario("Chrome", Order = 1)]
        public void BeforeScenarioChrome()
        {
            SelectBrowser(BrowserType.Chrome);
            _driver.Navigate().GoToUrl(TestSettings.CurrentUrl);
        }


        [BeforeScenario("Firefox", Order = 2)]
        public void BeforeScenarioFirefox()
        {
            SelectBrowser(BrowserType.Firefox);
            _driver.Navigate().GoToUrl(TestSettings.CurrentUrl);
        }

        [BeforeScenario("Edge", Order = 3)]
        public void BeforeScenarioEdge()
        {
            SelectBrowser(BrowserType.Edge);
            _driver.Navigate().GoToUrl(TestSettings.CurrentUrl);
        }

        [AfterScenario("Edge")]
        [AfterScenario("Chrome")]
        [AfterScenario("Firefox")]
        public void AfterScenatioEdge()
        {
            TestSettings.CurrentUrl = _driver.Url;
            DoAfterEach();
            _driver.Quit();
            _driver.Dispose();
        }

        public void DoAfterEach()
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
                    _driver = new ChromeDriver(Environment.CurrentDirectory);
                    _objectContainer.RegisterInstanceAs<IWebDriver>(_driver);
                    break;
                case BrowserType.Firefox:
                    _driver = new FirefoxDriver(Environment.CurrentDirectory);
                    _objectContainer.RegisterInstanceAs<IWebDriver>(_driver);
                    break;
                case BrowserType.Edge:
                    var option = new EdgeOptions();
                    option.UseChromium = true;
                    _driver = new EdgeDriver(Environment.CurrentDirectory, option);
                    _objectContainer.RegisterInstanceAs<IWebDriver>(_driver);
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

