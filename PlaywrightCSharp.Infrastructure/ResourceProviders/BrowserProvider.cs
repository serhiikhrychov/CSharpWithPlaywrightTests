using Microsoft.Extensions.Logging;
using Microsoft.Playwright;
using PlaywrightCSharp.Infrastructure.Helpers;

namespace PlaywrightCSharp.Infrastructure.ResourceProviders
{
    internal class BrowserProvider : PlaywrightResourceProvider<IBrowser>
    {
        public BrowserProvider(PlaywrightProvider playwrightProvider, PlaywrightConfig config, ILogger<BrowserProvider> logger)
            : base(CreateAsync(playwrightProvider, config, logger))
        {
        }

        private static async Task<IBrowser> CreateAsync(PlaywrightProvider playwrightProvider, PlaywrightConfig config, ILogger logger)
        {
            var playwright = await playwrightProvider.Resource;
            logger.LogInformation($"Selected browser: {config.Browser}");
            switch (config.Browser.ToLower())
            {
                case BrowserType.Chromium:
                    return await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
                    {
                        Headless = config.Headless,
                    });
                case BrowserType.Firefox:
                    return await playwright.Firefox.LaunchAsync(new BrowserTypeLaunchOptions
                    {
                        Headless = config.Headless,
                    });
                case BrowserType.Webkit:
                    return await playwright.Firefox.LaunchAsync(new BrowserTypeLaunchOptions
                    {
                        Headless = config.Headless,
                    });
            }

            throw new InvalidOperationException($"Unsupported browser: {config.Browser}");
        }
    }
}
