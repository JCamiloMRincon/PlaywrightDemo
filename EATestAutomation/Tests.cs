using EAFramework.Config;
using EAFramework.Driver;

namespace PlaywrightDemo
{
    public class Tests : IClassFixture<PlaywrightDriverInitializer>
    {
        private PlaywrightDriver _playwrightDriver;
        private IPlaywrightDriverInitializer _playwrightInitializer;

        public Tests(PlaywrightDriverInitializer playwrightDriverInitializer)
        {
            TestSettings testSettings = new TestSettings()
            {
                SlowMo = 0,
                Headless = false,
                DriverType = DriverType.Firefox
            };

            _playwrightInitializer = playwrightDriverInitializer;
            _playwrightDriver = new PlaywrightDriver(testSettings, _playwrightInitializer);
        }

        [Fact]
        public async Task Test1()
        {
            var page = await _playwrightDriver.Page;
            await page.GotoAsync("http://localhost:33084/");
            await page.ClickAsync("text=Privacy");
        }

        [Fact]
        public async Task Test2()
        {
            var page = await _playwrightDriver.Page;
            await page.GotoAsync("http://localhost:33084/");
            await page.ClickAsync("text=Product");
        }
    }
}