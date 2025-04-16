using Microsoft.Playwright;
using PlaywrightDemo.Config;

namespace PlaywrightDemo.Driver
{
    public class PlaywrightDriver
    {
        private readonly AsyncTask<IBrowser> _browser;
        private readonly AsyncTask<IBrowserContext> _browserContext;
        private readonly AsyncTask<IPage> _page;
        private readonly TestSettings _settings;
        private readonly IPlaywrightDriverInitializer _plawrightDriverInitializer;

        public PlaywrightDriver(TestSettings settings, IPlaywrightDriverInitializer plawrightDriverInitializer)
        {
            _settings = settings;
            _plawrightDriverInitializer = plawrightDriverInitializer;

            // Method groups in C#
            // https://www.delftstack.com/howto/csharp/method-groups-in-csharp/
            _browser = new AsyncTask<IBrowser>(InitializePlaywrightAsync);
            _browserContext = new AsyncTask<IBrowserContext>(CreateBrowserContextAsync);
            _page = new AsyncTask<IPage>(CreatePageAsync);
            _plawrightDriverInitializer = plawrightDriverInitializer;
        }

        // Apply the encapsultation principle of OOPs.
        public Task<IPage> Page => _page.Value;
        public Task<IBrowser> Browser => _browser.Value;
        public Task<IBrowserContext> BrowserContext => _browserContext.Value;

        private async Task<IBrowser> InitializePlaywrightAsync() 
        {
            return _settings.DriverType switch
            {
                DriverType.Chrome => await _plawrightDriverInitializer.GetChromeDriverAsync(_settings),
                DriverType.Chromium => await _plawrightDriverInitializer.GetChromiumDriverAsync(_settings),
                DriverType.Edge => await _plawrightDriverInitializer.GetEdgeDriverAsync(_settings),
                DriverType.Firefox => await _plawrightDriverInitializer.GetFirefoxDriverAsync(_settings),
                DriverType.Webkit => await _plawrightDriverInitializer.GetWebKitDriverAsync(_settings),
                _ => throw new NotImplementedException($"The driver type {_settings.DriverType} doesn't exist.")
            };
        }

        private async Task<IBrowserContext> CreateBrowserContextAsync() 
        { 
            return await (await _browser).NewContextAsync();
        }

        private async Task<IPage> CreatePageAsync() 
        {
            return await (await _browserContext).NewPageAsync();
        }
    }
}
