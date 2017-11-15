using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.PhantomJS;

namespace SeleniumMultipleBrowsers.xUnit
{
    public class BaseTest : IDisposable
    {
        protected IWebDriver Driver;
        private const string PATH_WEBDRIVER = @"C:\Users\webdrivers\";

        public static IEnumerable<object[]> BrowserType => new[]
        {
            new object[] { "Chrome" },
            new object[] { "Edge" },
            new object[] { "PhantomJS" }
        };

        public enum Browser
        {
            Chrome, Edge
        }

        protected void Initialize(string browser)
        {
            switch (browser)
            {
                case "Chrome":
                    this.Driver = new ChromeDriver(PATH_WEBDRIVER);
                    break;

                case "Edge":
                    this.Driver = new EdgeDriver(PATH_WEBDRIVER);
                    break;

                case "PhantomJS":
                    this.Driver = new PhantomJSDriver(PATH_WEBDRIVER);
                    break;
            }
        }

        protected void Initialize(Browser browser)
        {
            switch (browser)
            {
                case Browser.Chrome:
                    this.Driver = new ChromeDriver(PATH_WEBDRIVER);
                    break;

                case Browser.Edge:
                    this.Driver = new EdgeDriver(PATH_WEBDRIVER);
                    break;
            }
        }

        public void Dispose()
        {
            Driver.Quit();
            Driver?.Dispose();
        }
    }
}