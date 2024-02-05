using Microsoft.Playwright;

namespace PlaywrightCSharp.Infrastructure.ResourceProviders
{
    internal class PlaywrightProvider : PlaywrightResourceProvider<IPlaywright>
    {
        public PlaywrightProvider()
            : base(Playwright.CreateAsync())
        {
        }
    }
}
