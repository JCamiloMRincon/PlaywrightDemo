using Microsoft.Playwright;
using PlaywrightDemo.Config;
using PlaywrightDemo.Driver;

namespace PlaywrightDemo
{
    public class Tests
    {
        private IPage _page;
        private PlaywrightDriver _driver;

        [SetUp]
        public async Task Setup()
        {
            TestSettings testSettings = new TestSettings()
            {
                Channel = "firefox",
                SlowMo = 1500,
                Headless = false,
                DriverType = DriverType.Firefox
            };

            _driver = new PlaywrightDriver();
            _page = await _driver.InitializePlaywrightAsync(testSettings);
        }

        [Test]
        public async Task Test1()
        {
            await _page.ClickAsync("text=Privacy");
        }

        [Test]
        public async Task Test2()
        {
            await _page.ClickAsync("text=Product");
        }

        [TearDown]
        public async Task Teardown() 
        {
            // Code to tear-down the Playwright browser, browserContext
            // and disponse the resources.
            await _driver.Browser.CloseAsync();
            await _driver.Browser.DisposeAsync();
        }
    }
}