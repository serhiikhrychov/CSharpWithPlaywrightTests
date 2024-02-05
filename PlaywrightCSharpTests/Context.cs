using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PlaywrightCSharp.Infrastructure;
using PlaywrightCSharp.Infrastructure.Pages;

namespace PlaywrightCSharp.Tests
{
    [SetUpFixture]
    public class Context
    {
        private static ServiceProvider _serviceProvider;

        public static MainPage MainPage => Get<MainPage>();

        // here add a new pages if you need

        [OneTimeSetUp]
        public void OneTimeSetUp() => _serviceProvider = new ServiceCollection()
            .AddInfrastructure("config.json")
            .AddLogging(x => x.AddConsole())
            .BuildServiceProvider();

        private static T Get<T>() where T : notnull => _serviceProvider.GetRequiredService<T>();

        [OneTimeTearDown]
        public async Task OneTimeTearDownAsync() => await _serviceProvider.DisposeAsync();

    }
}
