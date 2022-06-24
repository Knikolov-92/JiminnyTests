using Jiminny.UITests.TestInfrastructure.Constants;
using Jiminny.UITests.TestInfrastructure.Managers;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Drawing;

namespace Jiminny.UITests.TestInrastructure.Drivers
{
    public sealed class Browser
    {
        private static readonly Lazy<Browser> LazyInit = new(() => new Browser());

        private Browser()
        {           
        }

        public static Browser Instance => LazyInit.Value;

        public IWebDriver WebDriver { get; set; }

        public WebDriverWait Wait { get; set; }

        public void CloseBrowser()
        {
            WebDriver.Quit();
            WebDriver.Dispose();
        }

       public IWebDriver OpenBrowser()
        {           
            var browserType = AppConfigManager.GetBrowser();

            switch (browserType)
            {
                case BrowserType.Chrome:

                    var chromeOptions = SetChromeOptions();
                    WebDriver = new ChromeDriver(chromeOptions);
                    break;
                case BrowserType.Firefox:

                    var firefoxOptions = SetFirefoxOptions();
                    WebDriver = new FirefoxDriver(firefoxOptions);
                    break;

                default:                    
                    WebDriver = new ChromeDriver(SetChromeOptions());
                    break;
            }
            
            WebDriver.Manage().Cookies.DeleteAllCookies();
            WebDriver.Manage().Window.Size = new Size(1920, 1080);
            WebDriver.Manage().Window.Maximize();

            Wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(Timeouts.DEFAULT_TIMEOUT_IN_SECONDS))
            {
                PollingInterval = TimeSpan.FromSeconds(Timeouts.DEFAULT_POLLING_TIME_IN_SECONDS)
            };

            return WebDriver;
        }

        public enum BrowserType
        {
            Chrome,
            Firefox
        }

        private static ChromeOptions SetChromeOptions()
        {
            return new ChromeOptions
            {
                PageLoadStrategy = PageLoadStrategy.Normal,
                Proxy = null
            };
        }

        private static FirefoxOptions SetFirefoxOptions()
        {
            return new FirefoxOptions
            {
                PageLoadStrategy = PageLoadStrategy.Normal,
                Proxy = null
            };
        }
    }
}
