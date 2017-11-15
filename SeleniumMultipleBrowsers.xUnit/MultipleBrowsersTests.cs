using OpenQA.Selenium;
using Xunit;

namespace SeleniumMultipleBrowsers.xUnit
{
    public class MultipleBrowsersTests : BaseTest
    {
        private void SeachByText(string text)
        {
            var textBox = Driver.FindElement(By.Name("q"));
            textBox.SendKeys(text);
            textBox.Submit();
        }

        [Theory, MemberData(nameof(BrowserType))]
        public void SearchBySameTextInGoogle_ByArray(string browser)
        {
            this.Initialize(browser);
            this.Driver.Navigate().GoToUrl("http://www.google.com");
            SeachByText("my text");
        }

        [Theory]
        [InlineData(Browser.Chrome)]
        [InlineData(Browser.Edge)]
        public void SearchBySameTextInGoogle_ByEnum(Browser browser)
        {
            this.Initialize(browser);
            this.Driver.Url = "http://www.google.com";
            SeachByText("my text");
        }
    }
}
