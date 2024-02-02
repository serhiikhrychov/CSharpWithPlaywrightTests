using Microsoft.Playwright;
using Newtonsoft.Json;
using PlaywrightCSharp.Infrastructure;

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
            string configPath = "config.json";
            string configJson = File.ReadAllText(configPath);
            dynamic config = JsonConvert.DeserializeObject(configJson);
            string browserType = (string)config.browser;

            playwright = await Playwright.CreateAsync();

            switch (browserType.ToLower())
            {
                case "chromium":
                    browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
                    {
                        Headless = config.headless,

                    });
                    break;
                case "firefox":
                    browser = await playwright.Firefox.LaunchAsync(new BrowserTypeLaunchOptions
                    {
                        Headless = config.headless,
                        // ...other options
                    });
                    break;
                case "microsoft edge":
                    browser = await playwright.Firefox.LaunchAsync(new BrowserTypeLaunchOptions
                    {
                        Headless = config.headless,
                        // ...other options
                    });
                    break;
                case "webkit":
                    browser = await playwright.Firefox.LaunchAsync(new BrowserTypeLaunchOptions
                    {
                        Headless = config.headless,
                        // ...other options
                    });
                    break;
                default:
                    throw new InvalidOperationException($"Unsupported browser: {config.browser}");
            }

            var page = await browser.NewPageAsync();
            await page.SetViewportSizeAsync((int)config.viewport.width, (int)config.viewport.height);
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
