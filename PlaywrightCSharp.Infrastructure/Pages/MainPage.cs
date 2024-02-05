using Microsoft.Extensions.Logging;
using Microsoft.Playwright;

namespace PlaywrightCSharp.Infrastructure.Pages
{
    public class MainPage
    {
        private IPage _page;
        private readonly ILogger<MainPage> _logger;

        public MainPage(IPage page, ILogger<MainPage> logger)
        {
            _page = page;
            _logger = logger;
        }

        private ILocator _searchFeild => _page.Locator("#searchboxinput");
        private ILocator _magnifyingSearchIcon => _page.Locator("#searchbox-searchbutton");
        private ILocator _directionsBtn => _page.GetByRole(AriaRole.Button, new() { Name = "Directions" });
        private ILocator _toDestinationField => _page.GetByRole(AriaRole.Textbox, new() { Name = "Choose starting point, or click on the map..." });

        public async Task GoTo()
        {
            await _page.GotoAsync("https://www.google.com/maps");
        }

        public async Task SearchViaSearchFieldBySpecificData(string data)
        {
            await _searchFeild.ClickAsync();
            await _searchFeild.FillAsync(data);
            await _magnifyingSearchIcon.ClickAsync();
        }

        public async Task BuildTheRoute(string to, string from)
        {
            await SearchViaSearchFieldBySpecificData(to);
            await _directionsBtn.ClickAsync();
            await _toDestinationField.FillAsync(from);
            await _page.Keyboard.PressAsync("Enter");
        }

        public async Task AsserAddressHasBeenFounded(string address)
        {
            var addressElement = _page.GetByText(address);
            await Assertions.Expect(addressElement).ToBeVisibleAsync();
        }

        public async Task AsserRouteIsBuilt()
        {
            await Assertions.Expect(_page.Locator("#section-directions-trip-title-0")).ToBeVisibleAsync();
        }

        public async Task AsserCantFindMessageIsDisplayed()
        {
            await Assertions.Expect(_page.GetByText("Google Maps can't find ")).ToBeVisibleAsync();
        }
    }
}
