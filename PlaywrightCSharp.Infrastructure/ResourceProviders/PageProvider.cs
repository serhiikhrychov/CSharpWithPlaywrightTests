using Microsoft.Extensions.Logging;
using Microsoft.Playwright;
using PlaywrightCSharp.Infrastructure.Helpers;

namespace PlaywrightCSharp.Infrastructure.ResourceProviders
{
    internal class PageProvider : PlaywrightResourceProvider<IPage>
    {
        public PageProvider(BrowserProvider browserProvider, PlaywrightConfig config, ILogger<IPage> logger)
            : base(CreateAsync(browserProvider, config, logger))
        {
        }

        private static async Task<IPage> CreateAsync(BrowserProvider browserProvider, PlaywrightConfig config, ILogger logger)
        {
            var browser = await browserProvider.Resource;
            var page = await browser.NewPageAsync();
            await page.SetViewportSizeAsync(config.Viewport.Width, config.Viewport.Height);
            logger.LogInformation($"View point for browser window: {config.Viewport.Width} x {config.Viewport.Height}");
            return page;
        }
    }
}
