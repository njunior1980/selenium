using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;

namespace SeleniumMultipleBrowsers
{

    [TestFixture]
    public class BaseTest
    {
        protected IWebDriver Driver;
        private const string PATH_WEBDRIVER = @"C:\Users\webdrivers\";

        protected static IEnumerable<string> BrowserType()
        {
            var browsers = new[] { "Chrome", "Edge" };
            foreach (var b in browsers)
                yield return b;
        }

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

        [TearDown]
        public void Teardown()
        {
            this.Driver.Quit();
            this.Driver?.Dispose();
        }
    }
}