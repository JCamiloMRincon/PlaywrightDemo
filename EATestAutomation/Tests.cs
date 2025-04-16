using EAFramework.Config;
using EAFramework.Driver;

namespace PlaywrightDemo
{
    public class Tests : IClassFixture<PlaywrightDriverInitializer>
    {
        private PlaywrightDriver _playwrightDriver;
        private TestSettings _testSettings;
        private IPlaywrightDriverInitializer _playwrightInitializer;

        public Tests(PlaywrightDriverInitializer playwrightDriverInitializer)
        {
            _testSettings = ConfigReader.ReadConfig();
            _playwrightInitializer = playwrightDriverInitializer;
            _playwrightDriver = new PlaywrightDriver(_testSettings, _playwrightInitializer);
        }

        [Fact]
        public async Task Test1()
        {
            var page = await _playwrightDriver.Page;
            await page.GotoAsync(_testSettings.ApplicationUrl);
            await page.ClickAsync("text=Login");
        }

        [Fact]
        public async Task Test2()
        {
            var page = await _playwrightDriver.Page;
            await page.GotoAsync(_testSettings.ApplicationUrl);
            await page.ClickAsync("text=Register");
        }
    }
}