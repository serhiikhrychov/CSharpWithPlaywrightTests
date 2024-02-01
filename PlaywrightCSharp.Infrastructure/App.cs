using Microsoft.Playwright;
using PlaywrightCSharp.Infrastructure.Pages;

namespace PlaywrightCSharp.Infrastructure
{
    public class App
    {
        public IPage Page { get; }
        public MainPage MainPage { get; }

        public App(IPage page)
        {
            Page = page;
            MainPage = new MainPage(page);
        }

        public async Task CloseAsync()
        {
            await Page.CloseAsync();
        }
    }
}
