using PlaywrightCSharp.Infrastructure.TestData;
using static PlaywrightCSharp.Tests.Context;

namespace PlaywrightCSharp.Tests.Tests;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class SearchPanelTests
{
    [SetUp]
    public void Setup()
    {

    }

    [Test]
    public async Task Search_SearchViaSearchFieldByPlaceName_PlaceIsFound()
    {
        await App.MainPage.GoTo();
        await App.MainPage.SearchViaSearchFieldBySpecificData(Places.PariserPlatzPlaceInBerlin);
        await App.MainPage.AsserAddressHasBeenFounded(Addresses.PariserPlatzAddressInBerlin);
    }

    [Test]
    public async Task Search_SearchViaSearchFieldByLatitudeAndLongitude_PlaceIsFound()
    {
        await App.MainPage.GoTo();
        await App.MainPage.SearchViaSearchFieldBySpecificData($"{Coordinates.LatitudePariserPlatzBerlin} {Coordinates.LongitudePariserPlatzBerlin}");
        await App.MainPage.AsserAddressHasBeenFounded(Places.PariserPlatzPlaceInBerlin);
    }

    [Test]
    public async Task Route_BuildARouteBetweenTwoCities_RouteIsBuilt()
    {
        await App.MainPage.GoTo();
        await App.MainPage.BuildTheRoute(Cities.PlaceAddressBerlin, Cities.PlaceAddressWarsaw);
        await App.MainPage.AsserRouteIsBuilt();
    }

    [Test]
    public async Task Search_SerchByInvalidValue_CantFindIsDisplayed()
    {
        await App.MainPage.GoTo();
        await App.MainPage.SearchViaSearchFieldBySpecificData(InvalidValues.BlankValue);
        await App.MainPage.AsserCantFindMessageIsDisplayed();
    }
}