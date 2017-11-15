using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;

namespace SeleniumMultipleBrowsers
{

    [TestFixture]
    [Parallelizable]
    public class MultipleBrowsersTests : BaseTest
    {
        private void SeachByText(string text)
        {
            this.Driver.FindElement(By.Id("lst-ib")).SendKeys(text);
            this.Driver.FindElement(By.Name("btnK")).Submit();

            Thread.Sleep(1000);
        }


        [Test]
        [TestCaseSource("BrowserType")]
        public void Search_By_Text_In_Google_By_Array(string browser)
        {
            this.Initialize(browser);
            this.Driver.Url = "http://www.google.com";
            SeachByText("my text");
        }

        [Test]
        [TestCase(Browser.Chrome)]
        [TestCase(Browser.Edge)]
        public void Search_By_Text_In_Google_By_Enum(Browser browser)
        {
            this.Initialize(browser);
            this.Driver.Url = "http://www.google.com";
            SeachByText("my text");
        }
    }
}
