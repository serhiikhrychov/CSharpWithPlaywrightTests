using Microsoft.Playwright;
using PlaywrightCSharp.Infrastructure;
using PlaywrightCSharp.Infrastructure.Helpers;

namespace PlaywrightCSharp.Tests
{
    [SetUpFixture]
    public class Context
    {
        public static App App { get; private set; }
        private IPlaywright playwright;
        private IBrowser browser;


        [OneTimeSetUp]
        public async Task OneTimeSetUpAsync()
        {
            //var serviceProvider = new ServiceCollection().AddLogging(x => x.AddConsole()).BuildServiceProvider();

            //var log = serviceProvider.GetRequiredService<ILogger>();

            PlaywrightConfigProvider playwrightProvider = new PlaywrightConfigProvider("config.json");

            var config = playwrightProvider.PlaywrightConfig;

            string browserType = config.Browser;

            playwright = await Playwright.CreateAsync();

            switch (browserType.ToLower())
            {
                case "chromium":
                    browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
                    {
                        Headless = config.Headless,
                    });
                    break;
                case "firefox":
                    browser = await playwright.Firefox.LaunchAsync(new BrowserTypeLaunchOptions
                    {
                        Headless = config.Headless,
                        // ...other options
                    });
                    break;
                case "microsoft edge":
                    browser = await playwright.Firefox.LaunchAsync(new BrowserTypeLaunchOptions
                    {
                        Headless = config.Headless,
                        // ...other options
                    });
                    break;
                case "webkit":
                    browser = await playwright.Firefox.LaunchAsync(new BrowserTypeLaunchOptions
                    {
                        Headless = config.Headless,
                        // ...other options
                    });
                    break;
                default:
                    throw new InvalidOperationException($"Unsupported browser: {config.Browser}");
            }

            var page = await browser.NewPageAsync();
            await page.SetViewportSizeAsync(config.Viewport.Width, config.Viewport.Height);
            await page.ScreenshotAsync(new() { Path = "screenshot.png" });
            App = new App(page);
        }



        [OneTimeTearDown]
        public async Task OneTimeTearDownAsync()
        {
            await App.CloseAsync();
            await browser.DisposeAsync();
            playwright.Dispose();
        }

    }
}
