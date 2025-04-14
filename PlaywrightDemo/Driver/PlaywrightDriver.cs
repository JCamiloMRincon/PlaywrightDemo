using Microsoft.Playwright;
using PlaywrightDemo.Config;

namespace PlaywrightDemo.Driver
{
    public class PlaywrightDriver
    {
        public IBrowser Browser;
        public IBrowserContext BrowserContext;

        public async Task<IBrowser> GetBrowserAsync(TestSettings settings) 
        {
            var playwrightDriver = await Playwright.CreateAsync();

            var browserOption = new BrowserTypeLaunchOptions() 
            {
                Headless = settings.Headless,
                Channel = settings.Channel,
                SlowMo = settings.SlowMo
            };

            return settings.DriverType switch
            {
                DriverType.Chrome => await playwrightDriver["chrome"].LaunchAsync(browserOption),
                DriverType.Chromium => await playwrightDriver.Chromium.LaunchAsync(browserOption),
                DriverType.Edge => await playwrightDriver["edge"].LaunchAsync(browserOption),
                DriverType.Firefox => await playwrightDriver.Firefox.LaunchAsync(browserOption),
                DriverType.Webkit => await playwrightDriver.Webkit.LaunchAsync(browserOption),
                _ => throw new NotImplementedException($"The driver type {settings.DriverType} doesn't exist.")
            };
        }

        public async Task<IPage> InitializePlaywrightAsync(TestSettings settings) 
        {
            Browser = await GetBrowserAsync(settings);
            BrowserContext = await Browser.NewContextAsync();
            var page = await BrowserContext.NewPageAsync();

            await page.GotoAsync("http://localhost:33084/");
            return page;
        }
    }
}
