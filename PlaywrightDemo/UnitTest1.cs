using PlaywrightDemo.Config;
using PlaywrightDemo.Driver;

namespace PlaywrightDemo
{
    public class Tests
    {
        private PlaywrightDriver _driver;
        private IPlaywrightDriverInitializer _initializer;

        [SetUp]
        public void Setup()
        {
            TestSettings testSettings = new TestSettings()
            {
                SlowMo = 0,
                Headless = false,
                DriverType = DriverType.Firefox
            };

            _initializer = new PlaywrightDriverInitializer();
            _driver = new PlaywrightDriver(testSettings, _initializer);
        }

        [Test]
        public async Task Test1()
        {
            var page = await _driver.Page;
            await page.GotoAsync("http://localhost:33084/");
            await page.ClickAsync("text=Privacy");
        }

        [Test]
        public async Task Test2()
        {
            var page = await _driver.Page;
            await page.GotoAsync("http://localhost:33084/");
            await page.ClickAsync("text=Product");
        }

        [TearDown]
        public async Task Teardown() 
        {
            // Code to tear-down the Playwright browser, browserContext
            // and disponse the resources.
            var browser = await _driver.Browser;
            await browser.CloseAsync();
            await browser.DisposeAsync();
        }
    }
}