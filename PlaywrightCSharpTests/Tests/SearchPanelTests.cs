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
        await MainPage.GoTo();
        await MainPage.SearchViaSearchFieldBySpecificData(Places.PariserPlatzPlaceInBerlin);
        await MainPage.AsserAddressHasBeenFounded(Addresses.PariserPlatzAddressInBerlin);
    }

    [Test]
    public async Task Search_SearchViaSearchFieldByLatitudeAndLongitude_PlaceIsFound()
    {
        await MainPage.GoTo();
        await MainPage.SearchViaSearchFieldBySpecificData($"{Coordinates.LatitudePariserPlatzBerlin} {Coordinates.LongitudePariserPlatzBerlin}");
        await MainPage.AsserAddressHasBeenFounded(Places.PariserPlatzPlaceInBerlin);
    }

    [Test]
    public async Task Route_BuildARouteBetweenTwoCities_RouteIsBuilt()
    {
        await MainPage.GoTo();
        await MainPage.BuildTheRoute(Cities.PlaceAddressBerlin, Cities.PlaceAddressWarsaw);
        await MainPage.AsserRouteIsBuilt();
    }

    [Test]
    public async Task Search_SerchByInvalidValue_CantFindIsDisplayed()
    {
        await MainPage.GoTo();
        await MainPage.SearchViaSearchFieldBySpecificData(InvalidValues.BlankValue);
        await MainPage.AsserCantFindMessageIsDisplayed();
    }
}