using Microsoft.Playwright;
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
            playwright = await Playwright.CreateAsync();
            browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = true });
            var page = await browser.NewPageAsync();
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
